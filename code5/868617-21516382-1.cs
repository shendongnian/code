     public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "Test",
                url: "Error/{errorMessage}",
                defaults: new { controller = "Error", action = "Index", errorMessage = "defaultErrorMessageTest" }
              );
            routes.MapRoute(
               name: "Defualt",
               url: "{controller}/{action}",
               defaults: new { controller = "Test", action = "DoStuff" }
             );           
        }
    }
     public class ErrorController : Controller
    {
        public ActionResult Index(string errorMessage)
        {
            ViewBag.Error = errorMessage;
            return View();
        }     
	}
     public class TestController : Controller
    {
        public ActionResult DoStuff()
        {
            return RedirectToAction("Index", "Error", new { errorMessage = "SomeError" });
        }
	}
