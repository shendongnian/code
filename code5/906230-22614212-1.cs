    // Find all repository abstractions
    var repositoryAbstractions = (
        from type in typeof(ICustomerRepository).Assembly.GetExportedTypes()
        where type.IsInterface
        where type.Name.EndsWith("Repository")
        select type)
        .ToArray();
    string pluginDirectory =
        Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Plugins");
    // Load all plugin assemblies
    var pluginAssemblies =
        from file in new DirectoryInfo(pluginDirectory).GetFiles()
        where file.Extension.ToLower() == ".dll"
        select Assembly.LoadFile(file.FullName);
    // Find all repository abstractions
    var repositoryImplementationTypes =
        from assembly in pluginAssemblies
        from type in assembly.GetExportedTypes()
        where repositoryAbstractions.Any(r => r.IsAssignableFrom(type))
        where !type.IsAbstract
        where !type.IsGenericTypeDefinition
        select type;
    // Register all found repositories.
    foreach (var type in repositoryImplementationTypes)
    {
        var abstraction = repositoryAbstractions.Single(r => r.IsAssignableFrom(type));
        container.Register(abstraction, type);
    }
