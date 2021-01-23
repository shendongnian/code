    public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
    
            routes.MapRoute(
                name: "DefaultApi",
                url: "rest/{controller}/{id}",
                defaults: new { controller="Home",action="Index",id = UrlParameter.Optional }
            );
    
        }
