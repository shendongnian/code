    [Fact]
    public void Configure1()
    {
        IWindsorContainer container = new WindsorContainer();
        var server = new MockFooServer();
        container.Register(Component.For<IEngine>().ImplementedBy<Engine>());
        foreach (Type type in Utils.GetConcreteTypesWithBase<DataProvider>())
        {
            container.Register(Component.For(type));
            server.AddService(type.Name, () => container.Resolve(type));
        }
        var service1 = server.services[typeof(Service1).Name];
        Assert.NotNull(service1);
    }
