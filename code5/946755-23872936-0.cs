    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "Song",
                url: "{songid}.song",
                defaults: new { controller = "Song", action = "Song",
                        /*id = UrlParameter.Optional*/ }
            );
            routes.MapRoute(
                "Default",                                              // Route name
                "{controller}/{action}/{id}",                           // URL with parameters
                new { controller = "Home", action = "Index", id = "" }  // Parameter defaults
            );
        }
        protected void Application_Start()
        {
            /// THE IMPORTANT PART
            RegisterRoutes(RouteTable.Routes);
        }
    }
