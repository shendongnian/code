    public static T GetParsedValueOrDefault<T>(string val)
    {
        IParse<T> parser = Parse.Create<T>();
        T ret;
        if (parser.TryParse(val, out ret)) {
            return ret;
        }
        return default(T);
    }
