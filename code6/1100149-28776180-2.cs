    // Simple Injector v3.x syntax
    container.RegisterCollection(typeof(IConfigTab),
        AppDomain.CurrentDomain.GetAssemblies());
    // Simple Injector v2.x syntax
    // Register all IConfigTabs we find in the current runtime 
    var iconfigTypes =
        from assembly in AppDomain.CurrentDomain.GetAssemblies()
        from type in assembly.GetExportedTypes()
        where !type.IsAbstract
        where typeof(IConfigTab).IsAssignableFrom(type)
        select type;
    container.RegisterAll(typeof(IConfigTab), iconfigTypes);
