    protected void Application_Start()
    {
        AreaRegistration.RegisterAllAreas();
        WebApiConfig.Register(GlobalConfiguration.Configuration);
        FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
        RouteConfig.RegisterRoutes(RouteTable.Routes);
        BundleConfig.RegisterBundles(BundleTable.Bundles);
        if (!(Roles.Provider is CustomRoleProvider)) // this call forces the Roles class to initialise
            typeof (Roles).GetField("s_Provider", BindingFlags.Static | BindingFlags.NonPublic).SetValue(null, _container.Resolve<CustomRoleProvider>());
        GlobalConfiguration.Configuration.Services.Replace(typeof(IHttpControllerActivator), _container.Resolve<IHttpControllerActivator>());
        ControllerBuilder.Current.SetControllerFactory(_container.Resolve<IControllerFactory>());
    }
