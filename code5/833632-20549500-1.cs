    private Type FindImplementation(
        IEnumerable<Assembly> assemblies, 
        Type serviceType)
    {
        var implementationType = (
            from dll in assemblies
            from type in dll.GetExportedTypes()
            where serviceType.IsAssignableFrom(type)
            where !type.IsAbstract
            where !type.IsGenericTypeDefinition
            select type)
            .SingleOrDefault();
        return implementationType;
    }
