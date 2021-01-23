    public void GetDataByAccountNumber_CalledTwiceDifferentInstance_DoesNotReturnFromCache()
    {
        var container = new Container();
        container.Register<IDynaCacheService>(() => new MemoryCacheService());
        container.Register(typeof(TestClass), Cacheable.CreateType<TestClass>());
        var instance1 = container.GetInstance<TestClass>();
        instance1.GetDataByAccountNumber(1);
        var instance2 = container.GetInstance<TestClass>();
        instance2.GetDataByAccountNumber(2);
        Assert.That(instance2.CallerId == 2);
    }
