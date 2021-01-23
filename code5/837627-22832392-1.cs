    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
    
            routes.RouteExistingFiles = true;
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
    
            routes.IgnoreRoute("content/themes/{filename}.html");
            routes.MapRoute("anyRoute", "content/themes/staticcontent.html", new { controller = "Account", action = "Register" });
        }
    }
