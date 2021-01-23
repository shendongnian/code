    public static IEnumerable<Type> GetAllStaticClassesInSolution()
    {
        var assemblies = AppDomain.CurrentDomain.GetAssemblies();
        return assemblies.SelectMany(assembly => assembly.DefinedTypes
                                                        .Where(x => x.IsClass && x.IsAbstract && x.IsSealed)
                                                        .Select(x => x.AsType()))
                                                        .Distinct();
    }
