    private static readonly MethodInfo ResolveMethodInfo
        = typeof(AppContainerInstaller).GetMethod("Resolve", BindingFlags.Public | BindingFlags.Static);
    // Assuming there exists a non-generic interface IMessageHandler
    private readonly ConcurrentDictionary<Type, Func<IMessageHandler>> _methodCache
        = new ConcurrentDictionary<Type, Func<IMessageHandler>>();
    public static string ProcessMessage(IMessage message)
    {
        messageHandler = Resolve(message.GetType());
        return messageHandler.Handle(message);
    }
    
    private IMessageHandler Resolve(Type type)
    {
        var resolve = _methodCache.GetOrAdd(type, () => ResolveMethodInfo.MakeGenericMethod(type));
        return resolve();
    }
