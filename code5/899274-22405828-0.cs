    private static IEnumerable<Assembly> GetFilteredAssemblies()
    {
        return AppDomainAssemblyTypeScanner.Assemblies
           .Where(x => !x.IsDynamic)
           .Where(x => !x.GetName().Name.StartsWith("Nancy", StringComparison.OrdinalIgnoreCase));
    }
