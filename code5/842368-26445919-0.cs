    public ScopedObjects(ILifetimeScope container, IModule module)
    {
        _c = container;
        _m = module;
    }
    public void Begin()
    {
        _scope = _c.BeginLifetimeScope(b => b.RegisterModule(_m));
    }
    public T Resolve<T>()
    {
        return _scope.Resolve<T>();
    }
    public void End()
    {
        _scope.Dispose();
    }
