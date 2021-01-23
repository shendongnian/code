    public static void RegisterRoutes(RouteCollection routes)
    {
           routes.MapRoute(
           name: "StudentList",
           url: "Students/{type}",
           defaults: new { controller = "Students", 
                           action = "Index", 
                           type = UrlParameter.Optional });
    }
