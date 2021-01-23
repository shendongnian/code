    protected void Application_Start()
    {
        var builder = new ContainerBuilder();
        builder.RegisterControllers(typeof(MvcApplication).Assembly);
        var container = builder.Build();
        DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
    
        // Other MVC setup...
    }
