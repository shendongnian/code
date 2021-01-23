    public static void ArgumentNotNull<T>(T arg, string name) where T : class
    {
        if (arg == null)
        {
            throw new ArgumentNullException(name);
        }
    }
