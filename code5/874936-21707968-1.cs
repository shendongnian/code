    protected void Application_Start()
    {
        AreaRegistration.RegisterAllAreas();
        WebApiConfig.Register(GlobalConfiguration.Configuration);
        FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
        RouteConfig.RegisterRoutes(RouteTable.Routes);
        BundleConfig.RegisterBundles(BundleTable.Bundles);
        var provider = Roles.Provider as CustomRoleProvider;
        if (provider != null) provider.Initialize(ConfigurationManager.AppSettings[ConnectionKey], ConfigurationManager.AppSettings[LogPathKey]);
        GlobalConfiguration.Configuration.Services.Replace(typeof(IHttpControllerActivator), _container.Resolve<IHttpControllerActivator>());
        ControllerBuilder.Current.SetControllerFactory(_container.Resolve<IControllerFactory>());
    }
