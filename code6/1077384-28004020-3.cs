    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using MvcApplication.Models;
    
    namespace MvcApplication.Controllers
    {
       public class StudentController : Controller
       {
           //
           // GET: /Student/
    
           public ViewResult Get()
           {
                ViewBag.Name = "Ali";
                ViewBag.SID = "45";            
                return View();
           }
       }
    }
