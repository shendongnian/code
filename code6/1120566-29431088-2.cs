    public static IEnumerable<T> NotEmpty<T> (IEnumerable<T> instance, string paramName = null)
    {
        if (instance != null && instance.Any())
            return instance;
        throw new Exception ();
    }
