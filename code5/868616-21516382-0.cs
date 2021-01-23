     public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
              name: "Test",
              url: "{controller}/{action}/{errorMessage}",
              defaults: new { controller = "Error", action = "Index", errorMessage = "defaultErrorMessageTest" }
            );
            routes.MapRoute(
              name: "Defualt",
              url: "{controller}/{action}",
              defaults: new { controller = "Error", action = "DoStuff" }
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
        public ActionResult DoStuff()
        {
            return RedirectToAction("Index", "Error", new { errorMessage = "SomeError" });
        }
	}
