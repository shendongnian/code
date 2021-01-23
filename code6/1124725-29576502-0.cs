    void Application_Start(object sender, EventArgs e)
    {
        var builder = new ContainerBuilder();
        IEnumerable<Assembly> assemblies = AppDomain.CurrentDomain.GetAssemblies();
        if (HostingEnvironment.InClientBuildManager)
        {
            assemblies = assemblies.Union(BuildManager.GetReferencedAssemblies()
                                                      .Cast<Assembly>())
                                   .Distinct();
        }
        builder.RegisterAssemblyModules(assemblies);
        _containerProvider = new ContainerProvider(builder.Build());
    }
