    public static IMessageHandler Resolve<T>(T parameters)
    {
        var type = _handlers[parameters.GetType().FullName];
        return (IMessageHandler)Activator.CreateInstance(type);
    }
