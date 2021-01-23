    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using WebApplication5.Models;
    
    namespace WebApplication.Controllers
    {
        public class HomeController : Controller
        {
            private List<MyService> LoadServices()
            {
                List<MyService> myServices = new List<MyService>();
    
                for (int i = 0; i < 3; i++)
                {
                    MyService msvc = new MyService();
                    msvc.ServiceUrl = "service_url" + i.ToString() + ".html";
                    msvc.ServiceImageUrl = "image_url" + i.ToString() + ".jpg";
                    msvc.ServiceName = "Service " + i.ToString();
                    msvc.ServiceDescription = "Service Description " + i.ToString();
    
                    myServices.Add(msvc);
                }
    
                return myServices;
            }
    
            public ActionResult Services()
            {
                // return a view using the ViewModel provided by LoadServices()
                return View(LoadServices());
            }
        }
    }
