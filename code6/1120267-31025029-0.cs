    public IEnumerable<Assembly> GetLoadedAssemblies()
    {
        return _libraryManager.GetReferencingLibraries(_coreAssemblyName.Name)
                              .Select(info => Assembly.Load(new AssemblyName(info.Name)));
    }
