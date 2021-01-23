    public class RouteConfigTest
        {
            public static void LoadRoutes(RouteCollection routes)
            {
                routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
                routes.MapRoute(name: "Default", url: "{controller}/{action}/{id}", 
                    defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional, catchAll = "" });
            }
        }
