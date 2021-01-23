    public static T1 NotEmpty<T1>(T1 argument, string message = null) where T1 : class, IEnumerable
    {
        if (argument == null)
            throw new ArgumentNullException(message);
        if(!argument.OfType<Object>().Any())
            throw new ArgumentException(message);
        return argument;
    }
