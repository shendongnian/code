     using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Web;
        using System.Web.Mvc;
        using System.Web.Mvc.Ajax;
        
        namespace Web.Controllers {
        
            public class HomeController : Controller {
        
                [SessionExpireFilter]
                public ActionResult Index( ) {
                    // This method will not execute if our session has expired
        
                    // render Home Page
                    return View();
                }
        
                public ActionResult Login() {
                    // render Login page
                    return View();
                }
            }
        }
