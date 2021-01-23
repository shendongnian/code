    protected void Application_Start()
    {
        var container = new Container();
        
        container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
        
        container.Register<Profile>(() => new ProfileWrapper().CurrentUser());
        container.Register<Settings>(() => new SettingsWrapper().CurrentSiteSettings());
        
        DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
    }
