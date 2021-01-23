    [Fact]
    public void RegisterAll_Contravariant_Succeeds()
    {
        var container = new Container();
        container.RegisterManyForOpenGeneric(
            typeof(INotificationHandler<>),
            (service, impls) => container.RegisterAll(service, impls),
            AppDomain.CurrentDomain.GetAssemblies());
        var handlersType = typeof(IEnumerable<INotificationHandler<Pinged>>);
        var handlersCollection = (
            from r in container.GetCurrentRegistrations()
            where handlersType.IsAssignableFrom(r.ServiceType)
            select r.GetInstance())
            .Cast<IEnumerable<INotificationHandler<Pinged>>>()
            .ToArray();
        var result = 
            from handlers in handlersCollection
            from handler in handlers
            select handler;
        Assert.Equal(3, result.Count());
    }
