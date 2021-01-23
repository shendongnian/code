    public static void CheckNotNull(params object[] args)
    {
        if (args == null)
        {
            throw new ArgumentNullException(nameof(args))
        }
    }
