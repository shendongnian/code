    var assembly = Assembly.GetExecutingAssembly();
    ContainerBuilder builder = new ContainerBuilder();
    builder.RegisterAssemblyTypes(assembly)
        .Where(t => t.Name.EndsWith("Repository"))
        .As(t => t.GetInterfaces()[0]);
