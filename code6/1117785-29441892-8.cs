    protected void Application_Start()
    {
        AreaRegistration.RegisterAllAreas();
        GlobalConfiguration.Configure(WebApiConfig.Register);
        FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
        RouteConfig.RegisterRoutes(RouteTable.Routes);
        BundleConfig.RegisterBundles(BundleTable.Bundles);
        var allDirectRoutes = WebApiConfig.GlobalObservableDirectRouteProvider.DirectRoutes;
        // now do something with 'allDirectRoutes'
    }
