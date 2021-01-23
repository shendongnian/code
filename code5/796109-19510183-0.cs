    public void RegisterPlugin<T1>() where T1 : IWebrolePlugin
    {
        try
        {
            _container.RegisterType<T1>(typeof(T1).Name, 
                new ContainerControlledLifetimeManager());
            _container.RegisterType<IWebrolePlugin, T1>(typeof(T1).Name);
        }
        catch (Exception e)
        {
            Trace.TraceError(e.ToString());
        }
    }
    public T GetPlugin<T>() where T : IWebrolePlugin
    {
        return _container.Resolve<T>(typeof(T).Name);
    }
