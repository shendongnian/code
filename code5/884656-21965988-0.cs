    public static IEnumerable<KeyValuePair<string, object>> GetTypeValues<T>(T typeObject) where T : class
    {
        // typeObject specific operations
        IEnumerable<KeyValuePair<string, object>> typeValues = 
            typeObject
            .GetType()
            .GetProperties()
            .Select(property => new KeyValuePair<string, object>(property.Name, property.GetValue(typeObject)));
        return typeValues;
    }
