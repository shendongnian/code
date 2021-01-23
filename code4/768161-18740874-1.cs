    protected void Application_Start()
    {
        RouteTable.Routes.MapHubs();
        AreaRegistration.RegisterAllAreas();
        ModelBinders.Binders.Add(typeof(decimal), new DecimalModelBinder());
        ModelBinders.Binders.Add(typeof(decimal?), new DecimalModelBinder());
        // All other code.
    }
