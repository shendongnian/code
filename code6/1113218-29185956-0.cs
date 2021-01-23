        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
    
            routes.MapRoute(
              name: "Servers",
              url: "{controller}/{action}/{id}/{a}",
              defaults: new
              {
                controller = "Test",
                id = UrlParameter.Optional,
                a = UrlParameter.Optional 
              }
            );
        }
