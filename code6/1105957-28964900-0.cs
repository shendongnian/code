    public static void RegisterRoutes(RouteCollection routes)
    {
        routes.IgnoreRoute("SomeFolder/{*pathInfo}");
        // your other routes
    }
