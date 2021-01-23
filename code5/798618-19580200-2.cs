    public ProxyInstance(Type type)
    {
        ConcreteType = type; // the type for our Wrapper, the real implementation
    }
    protected override object build(Type pluginType, BuildSession session)
    {
        var aopFilters = 
             // my custom way how to inject more AOP filters
             AopFilterManager.GetFilters()
             // the core for us, one of the interceptors is our Wrapper
            .Union(new[] { new Wrapper(ConcreteType) })
            .ToArray();
    
        // Castle will emit a proxy for us, but the Wrapper will do the job
        var proxy = Factory
             .CreateClassProxy(ConcreteType, AopFilterManager.AopOptions, aopFilters);
    
        return proxy;
    }
