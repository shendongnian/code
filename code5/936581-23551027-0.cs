    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {            
            routes.MapRoute(
                name: "CatchAll",
                url: "{*catchall}",
                defaults: new { controller = "Home", action = "CatchAll" }
            );
        }
    }
    public class HomeController : Controller
    {       
        public ActionResult CatchAll(string catchall)
        {
            catchall = catchall ?? "null";
            var index = catchall.IndexOf("-");
            if (index >= 0)
            {
                var id = catchall.Substring(0, index);
                var title = catchall.Substring(index+1);
                return Content(string.Concat("id: ", id, " title: ", title));
            }
            return Content(string.Concat("No match: ", catchall));
        }
    }
