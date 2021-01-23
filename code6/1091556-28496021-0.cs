    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{blogTitle}",
                defaults: new { controller = "Home", action = "Index", blogTitle = UrlParameter.Optional }
            );
        }
    }
