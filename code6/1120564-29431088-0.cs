    public static IEnumerable<T> NotEmpty<IEnumerable<T>> (IEnumerable<T> instance, string paramName = null)
    {
        if (instance != null)
            if (instance.Any ())
                return instance;
        throw new Exception ();
    }
