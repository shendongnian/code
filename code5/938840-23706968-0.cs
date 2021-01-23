    var assemblies = AppDomain.CurrentDomain.GetAssemblies(); 
    List<Type> types = new List<Type>();
    foreach (var assembly in assemblies) 
    {
        types.AddRange(GetModules(assembly)); 
    }
    
    
        IEnumerable<Type> GetModules(Assembly assembly)
        {
             assembly.GetTypes()
                  .Where(t => t.BaseType == typeof(NinjectModule));       
        }
