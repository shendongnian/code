    public static void RegisterRoutes(RouteCollection routes)
            {
                routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
    
                routes.MapRoute("Robots.txt",
                    "robots.txt",
                    new { controller = "robot", action = "index" });
    
                //routes.MapRoute(
                //    name: "Localization",
                //    url: "{lang}/{controller}/{action}/{id}",
                //    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                //    constraints: new { lang = @"^[a-zA-Z]{2}$" }
    
                //);
    
                routes.MapRoute(
                    name: "Default",
                    url: "{controller}/{action}/{id}",
                    defaults: new
                    {
                        controller = "Home",
                        action = "Index",
                        id = UrlParameter.Optional
                    },
                    constraints: new { controller = GetAllControllersAsRegex() } 
                    );
        
                //Adds a catchall route
                routes.MapRoute(
                "NotFound",
                "{*url}",
                new { controller = "Error", action = "Error404" }
                );
    
                routes.MapMvcAttributeRoutes();
            }
