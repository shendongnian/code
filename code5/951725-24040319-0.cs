        var builder = new ContainerBuilder();
        builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
        var assemblies = AppDomain.CurrentDomain.GetAssemblies().ToList();
        var appAssemblies = assemblies.Where(a => a.ToString().StartsWith("MyCustomer.MyApplicationName") && !a.ToString().Contains("Services")).ToArray();
        builder.RegisterAssemblyTypes(appAssemblies).AsImplementedInterfaces();
        var container = builder.Build();
        var resolver = new AutofacWebApiDependencyResolver(container);
        GlobalConfiguration.Configuration.DependencyResolver = resolver;
