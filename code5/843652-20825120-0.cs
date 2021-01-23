        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Web;
        using System.Web.Mvc;
        namespace test2.Controllers
        {
        public class HomeController : Controller
        {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult FileUpload(HttpPostedFileBase file)
        {
            if (file != null)
            {
                Database1Entities db = new Database1Entities();
                string ImageName = System.IO.Path.GetFileName(file.FileName);
                string physicalPath =Server.MapPath("~/images/"+ ImageName);
                // save image in folder
                file.SaveAs(physicalPath);
                //save new record in database
                tblA newRecord = new tblA();
                newRecord.fname = Request.Form["fname"];
                newRecord.lname = Request.Form["fname"];
                newRecord.imageUrl = ImageName;
                db.tblAs.Add(newRecord);
                db.SaveChanges();
            }
            //Display records
            return RedirectToAction("../home/Display/");
        }
        public ActionResult Display()
        {
            return View();
        }
        }
        }
