    public void RegisterDependencies(Container container)
    {
        // Container is a Structure Map container.
        container.ForRequestedType<IUnitOfWork>()
            .CacheBy(InstanceScope.HttpContext)
            .TheDefaultConcreteType<DbContext>();    
    }
