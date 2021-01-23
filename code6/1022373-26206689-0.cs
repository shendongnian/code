    var baseType = typeof(Base);
    var currentlyLoadedAssemblies = AppDomain.Current.GetAssemblies();
    var relevantTypes = currentlyLoadedAssemblies
           .SelectMany (assembly => assembly.GetTypes())
           .Where(type => baseType.IsAssignableFrom(type));
    Types = relevantTypes.ToList();
