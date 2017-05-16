using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CrudDemo.Models;

namespace CrudDemo.Controllers
{
    public class PlayerController : Controller
    {
        private CrudContext _context = null;

        public PlayerController()
        {
            _context = new CrudContext();
        }

        // GET: Player
        public JsonResult GetPlayers()
        {
            List<Player> listPlayers = _context.Players.ToList();
            return Json(new { list = listPlayers }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetPlayerById(int id)
        {
            Player player = _context.Players.Where(item => item.PlayerId == id).FirstOrDefault();
            return Json(new { player = player }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult AddPLayer(Player player)
        {
            _context.Players.Add(player);
            _context.SaveChanges();
            return Json(new { status = "Player added successfully" });
        }

        public JsonResult UpdatePLayer(Player player)
        {
            _context.Entry(player).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
            return Json(new { status = "Player updated successfully" });
        }

        public JsonResult DeletePlayer(int id)
        {
            Player player = _context.Players.Where(item => item.PlayerId == id).FirstOrDefault();
            _context.Players.Remove(player);
            _context.SaveChanges();
            return Json(new { status = "Player deleted successfully" });
        }
    }
}