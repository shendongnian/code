    public static MyTypedSession GetMyTypedSession(this ICacheClient cache)
    {
        var typedSession = ServiceStackHost.Instance.Container.TryResolve<MyTypedSession>();
      
        if (typedSession != default(MyTypedSession))
            return typedSession;
    
        return cache.SessionAs<MyTypedSession>();
    }
