    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
             routes.MapRoute("someController", "some/someAction",
                new { controller = "Some", action = "SomeAction" });
        }
    }
