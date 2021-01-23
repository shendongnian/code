    protected override IEnumerable<Assembly> SelectAssemblies()
    {
        return new[]
        {    
            typeof (IEventAggregator).GetTypeInfo().Assembly,
            typeof (IWindowManager).GetTypeInfo().Assembly,
            typeof (MefBootstrapper).GetTypeInfo().Assembly
        };
    }    
    
    protected override void Configure()
    {
        var config = new ContainerConfiguration();
    
        // note that the event aggregator is in the core CM assembly,
        // while the window manager in the platform-dependent CM assembly,
        // so that we need 2 conventions for 2 assemblies.
        ConventionBuilder cmBuilder = new ConventionBuilder();
        cmBuilder.ForType<EventAggregator>().Export<IEventAggregator>();
        ConventionBuilder cmpBuilder = new ConventionBuilder();
        cmpBuilder.ForType<WindowManager>().Export<IWindowManager>();
        ConventionBuilder appBuilder = new ConventionBuilder();
        appBuilder.ForTypesMatching(t =>
            t.Name.EndsWith("ViewModel", StringComparison.OrdinalIgnoreCase)).Export();
        appBuilder.ForType<MainViewModel>().Export<IShell>();
        config.WithAssembly(typeof(IEventAggregator).GetTypeInfo().Assembly, cmBuilder);
        config.WithAssembly(typeof(IWindowManager).GetTypeInfo().Assembly, cmpBuilder);
        config.WithAssembly(typeof(MefBootstrapper).GetTypeInfo().Assembly, appBuilder);
        _host = config.CreateContainer();
    }
