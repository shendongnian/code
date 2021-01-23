    public IEnumerable<Type> GetLoadedOpenGenericImplementations(Type type)
    {
        var types =
            from assembly in AppDomain.CurrentDomain.GetAssemblies()
            from t in assembly.GetTypes()
            where !t.IsAbstract
            from i in t.GetInterfaces()
            where i.IsGenericType
            where i.GetGenericTypeDefinition() == type
            select t;
        return types;
    }
