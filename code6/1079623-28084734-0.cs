    public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "Default",
                url: "{applicationcode}/{controller}/{action}/{id}",
                defaults: new { applicationcode = "WebApplication", controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
