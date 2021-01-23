    public static IEnumerable<ConstructorInfo> GetAllStaticConstructorsInSolution()
    {
       var assemblies = AppDomain.CurrentDomain.GetAssemblies();
    
       return assemblies.SelectMany(assembly => assembly.DefinedTypes
                       .Where(type => type.DeclaredConstructors.Any(constructorInfo => constructorInfo.IsStatic))
                       .SelectMany(x => x.GetConstructors(BindingFlags.Static)))
                       .Distinct();
    }
