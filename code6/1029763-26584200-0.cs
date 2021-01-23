    protected void Application_Start()
    {
        RouteConfig.RegisterRoutes(RouteTable.Routes);
        AreaRegistration.RegisterAllAreas();
        // ...
    }
