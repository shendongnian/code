    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
               routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
                routes.MapRoute(
                "addorders", // Route name
                "addorders/{id}/{str}", // URL with parameters
                new { controller = "Home", action = "addorders", id = UrlParameter.Optional, str = UrlParameter.Optional },// Parameter defaults
                   new[] { "AngularJsExample.Controllers" }
               );
    
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
