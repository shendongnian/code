    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using MvcTwitterBootstrap.Models;
    
    namespace MvcTwitterBootstrap.Controllers
    {
        public class HomeController : Controller
        {
            //
            // GET: /Home/
            public ActionResult Index()
            {
                return View();
            }
    
            [HttpPost]
            public ActionResult Create(MyViewModel model)
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        SaveChanges(model);
                        return Json(new { success = true });
                    }
                    catch (Exception e)
                    {
                        ModelState.AddModelError("", e.Message);
                    }
    
                }
                //Something bad happened
                return PartialView("_Create", model);
            }
    
    
            static void SaveChanges(MyViewModel model)
            {
                // Uncommment next line to demonstrate errors in modal
                //throw new Exception("Error test");
            }
    
        }
    }
