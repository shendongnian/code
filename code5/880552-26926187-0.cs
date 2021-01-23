    protected void Application_Start() 
    {
        AreaRegistration.RegisterAllAreas();
        RegisterRoutes(RouteTable.Routes);
        //...
        Database.SetInitializer<MyContext>(null);
    }
