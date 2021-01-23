        routes.MapRoute(
            "Default", // Route name
            "{controller}/{action}/{id}", // URL with parameters
            new { controller = "Home", action = "Index",
                  id = UrlParameter.Optional } // Parameter defaults
        );
        routes.MapRoute(
            "Home", // Route name
            "{controller}/{action}/{filter}", // URL with parameters
            new { controller = "Home", action = "ListCompanies", 
                  filter = UrlParameter.Optional} // Parameter defaults
        );
