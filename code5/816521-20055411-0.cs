    public static IEnumerable<Type> GetSubclassesForType(Type baseClassType)
    {
        List<Type> types = new List<Type>();
        foreach (Assembly ass in AppDomain.CurrentDomain.GetAssemblies())
        {
           types.AddRange(ass.GetTypes().Where(type => type.IsSubclassOf(baseClassType)));
        }
        return types;
    }
    public static IEnumerable<Type> GetSubclassesForType(Assembly assembly, Type baseClassType)
    {
        return from type in assembly.GetTypes() 
                            where type.IsSubclassOf(baseClassType)    
                            select type;
    }
