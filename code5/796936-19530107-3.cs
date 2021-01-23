    static Mapper()
    {
        PropertyMap = typeof(T).GetProperties(BindingFlags.Public |
                                                  BindingFlags.NonPublic |
                                                  BindingFlags.Instance)
                                                  .ToDictionary(p => p.Name.ToLower(), p => p);
    
        FieldMap = typeof(T).GetFields(BindingFlags.Public |
                                                    BindingFlags.NonPublic |
                                                    BindingFlags.Instance)
                                                    .ToDictionary(f => f.Name.ToLower(), f => f);
    }
