    var assembly = Assembly.GetExecutingAssembly();
    IEnumerable<Type> types = 
          assembly.DefinedTypes.Where(t => IsImplementingIDisposable(t))
                               .Select(t => t.UnderlyingSystemType);
    
    ........
    
    private static bool IsImplementingIDisposable(TypeInfo t)
    {
         return typeof(IDisposable).IsAssignableFrom(t.UnderlyingSystemType);
    }
