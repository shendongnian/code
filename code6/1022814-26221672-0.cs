    public static bool Validate<T>(string value)
    {
       var flags = BindingFlags.Public | BindingFlags.Static;
       var method = typeof(T).GetMethod(
                "TryParse",
                flags,
                null,
                new[] { typeof(string), typeof(T).MakeByRefType() },
                null);
        if (method != null)
        {
             T result = default(T);
             return (bool)method.Invoke(null, new object[] { value, result });
        }
        else
        {
            // there is no appropriate TryParse method on T so the type is not supported
        }
    }
