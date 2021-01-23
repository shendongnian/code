    protected void Application_Start()
    {
        AreaRegistration.RegisterAllAreas();
        FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
        RouteConfig.RegisterRoutes(RouteTable.Routes);
        GlobalConfiguration.Configure(WebApiConfig.Register); //I AM THE 4th
        BundleConfig.RegisterBundles(BundleTable.Bundles);
    }      
