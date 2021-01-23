        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapRoute(
                "...",                                              // Route name
                "{controller}/{action}/{id}",                           // URL with parameters
                new { controller = "Home", action = "Index", id = "" }  // Parameter defaults
            );
            routes.MapRoute(
                "...",                                              // Route name
                "{controller}/{action}",                           // URL with parameters
                new { controller = "Home", action = "Index", id = "" }  // Parameter defaults
            );
            routes.MapRoute(
                "...",                                              // Route name
                "{controller}/{action}/{id}",                           // URL with parameters
                new { controller = "Customer", action = "GetImage", id = "" }  // Parameter defaults
            );
            routes.MapRoute(
                "...",                                              // Route name
                "Customer/GetImage/{id}",                           // URL with parameters
                new { controller = "Customer", action = "GetImage", id = "" }  // Parameter defaults
            );
            ..... //all of these mentioned route will land on the same url 
        }
        protected void Application_Start()
        {
            RegisterRoutes(RouteTable.Routes);
        }
