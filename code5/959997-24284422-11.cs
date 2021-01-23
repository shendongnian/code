    [Test]
    public void GetDataByAccountNumber_CalledTwiceSameInstance_ReturnsCacheSecondTime()
    {
        var container = new Container();
        container.Register<IDynaCacheService>(() => new MemoryCacheService());
        container.Register(typeof(TestClass), Cacheable.CreateType<TestClass>());
        var instance = container.GetInstance<TestClass>();
        instance.GetDataByAccountNumber(1);
        instance.GetDataByAccountNumber(2);
        Assert.That(instance.CallerId == 1);
    }
