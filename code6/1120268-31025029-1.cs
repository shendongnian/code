    public IEnumerable<Assembly> GetLoadedAssemblies()
    {
        return _libraryManager.GetReferencingLibraries(_coreAssemblyName.Name)
                              .SelectMany(info => info.Assemblies)
                              .Select(info => Assembly.Load(new AssemblyName(info.Name)));
    }
