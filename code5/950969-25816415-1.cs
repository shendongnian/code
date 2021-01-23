    public MyController(ISession session, IContainer container)
    {
        _session = session;
        _container = container;
    }
    public void DoSomeStuff()
    {
        _container.Inject(new FooBar());
    }
