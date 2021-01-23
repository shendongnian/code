    static BaseStringEnum()
    {
        var StringEnumTypes = AppDomain.CurrentDomain.GetAssemblies()
              .SelectMany(a => a.GetTypes())
              .Where(type => type.IsSubclassOf(typeof(BaseStringEnum<T>)));
    
        foreach (var T in StringEnumTypes) T.TypeInitializer.Invoke(null, null);
    }
