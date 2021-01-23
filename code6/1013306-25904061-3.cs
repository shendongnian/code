    static BaseStringEnum()
    {
        var StringEnumTypes = AppDomain.CurrentDomain.GetAssemblies()
              .SelectMany(a => a.GetTypes())
              .Where(type => type.IsSubclassOf(typeof(BaseStringEnum<T>)));
    
        foreach (var type in StringEnumTypes) type.TypeInitializer.Invoke(null, null);
    }
