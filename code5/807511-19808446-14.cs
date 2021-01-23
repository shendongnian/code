    [Test]
    public void GetInstance_A_HasCustomAbsoluteExpiration()
    {
        Container container = ConfigureContainer();
        var a = container.GetInstance<IQueryHandler<A, AResult>>();
        Assert.AreNotEqual(
            (a as CachingQueryHandlerDecorator<A, AResult>).Policy.AbsoluteExpiration,
            Cache.NoAbsoluteExpiration);
    }
    [Test]
    public void GetInstance_B_HasDefaultAbsoluteExpiration()
    {
        Container container = ConfigureContainer();
        var b = container.GetInstance<IQueryHandler<B, BResult>>();
        Assert.AreEqual(
            (b as CachingQueryHandlerDecorator<B, BResult>).Policy.AbsoluteExpiration,
            Cache.NoAbsoluteExpiration);
    }
