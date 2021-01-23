    protected void Application_Start()
    {
        this.RegisterAutoFac();
        // Rest of method
    }
    private void RegisterAutoFac()
    {
        var builder = new ContainerBuilder();
        builder.RegisterControllers(typeof(MvcApplication).Assembly);
        builder.RegisterType<MyClass>().As<IMyClass>();
        builder.RegisterType<MyCache>().As<IMyCache>().SingleInstance();
        var container = builder.Build();
        // Setup the dependency resolver
        DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
    }
