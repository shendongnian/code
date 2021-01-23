    using PestTypeTest.Models;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    
    namespace PestTypeTest.Controllers
    {
        public class PestTypeController : Controller
        {
            //
            // GET: /PestType/
            public ActionResult Index()
            {
                return RedirectToAction("Create");
            }
    
            public ActionResult Create()
            {
                ViewBag.PestType = new SelectList(Enum.GetValues(typeof(PestType)).OfType<PestType>());
                return View();
            }
    
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Create(//(SinglePest singlepest)
            [Bind(Include = "Alias, TechName, SerialNumber, PestType, Markings")] SinglePest singlepest)
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        //db.SinglePests.Add(singlepest);
                        //db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                }
                catch (DataException /* dex */)
                {
    
                    ModelState.AddModelError("", "Unable to save changes, try again, if problem   persits contact your administrator");
                }
    
                //ViewBag.SerialNumber = new SelectList(db.Sources, "SerialNumber", "SerialNumber", singlepest.SerialNumber);
                ViewBag.PestType = new SelectList(Enum.GetValues(typeof(PestType)).OfType<PestType>(), singlepest.PestType);
                return View(singlepest);
            }
    	}
    }
