    IContainer container = new Container();
    container.Configure(c => {
        c.IncludeRegistry<YourRegistry>();
    });
    DependencyResolver.SetResolver(new StructureMapDependencyResolver(container));
