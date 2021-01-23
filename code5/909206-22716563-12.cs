    private Container ContainerFactory()
    {
        var container = new Container();
        var types = this.GetLoadedOpenGenericImplementations(typeof(IHandler<>));
        container.RegisterAllOpenGeneric(typeof(IHandler<>), types);
        container.RegisterOpenGeneric(
            typeof(ContainerResolvedClass<>),
            typeof(ContainerResolvedClass<>));
        return container;
    }
