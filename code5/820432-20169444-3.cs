    public void Subscribe<TMessage>(Action<TMessage> handler)
    {
        [...]
        object targetObject = handler.Target;
        MethodInfo method = handler.Method;
        new Subscriber(targetObject, method)
        [...]
        subscriber.method.Invoke(subscriber.object, new object[]{message});
