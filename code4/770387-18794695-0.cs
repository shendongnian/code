    public static void RegisterRoutes(RouteCollection routes)
    {
      //all your other routes
    
      routes.MapRoute(
        "Default",                                              // Route name
        "{controller}/{action}/{id}",                           // URL
        new { controller = "Home", action = "Index", id = "" }, // Defaults
        new[]{"Your.NameSpace"}                       // Namespaces
      );
    }
