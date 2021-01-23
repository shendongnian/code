    public static void RegisterRoutes(RouteCollection routes)
    {
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
 
        // Setup attributing routing rules
        routes.MapMvcAttributeRoutes();
        // You can comment out the old routing if you don't need it, 
        // but it can work in hybrid mode without issues
        routes.MapRoute(
            name: "Default",
            url: "{controller}/{action}/{id}",
            defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
        );
    }
    
