    public class HomeController : Controller
    {
        public async Task<ActionResult> Index()
        {
            await Task.Delay(1000);
            ViewBag.Message = "Modify this template to jump-start blah .. blah";
            return View();
        }
        ...
    }
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", 
                                id = UrlParameter.Optional }
            );
        }
    }
