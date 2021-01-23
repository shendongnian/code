    [Test]
    public void GetDataByAccountNumber_CalledTwiceLifetimeScopedInstance_ReturnsCacheSecondTime()
    {
        var container = new Container();
        container.Register<IDynaCacheService>(() => new MemoryCacheService());
        container.Register(typeof(TestClass), Cacheable.CreateType<TestClass>(), new LifetimeScopeLifestyle());
        using (container.BeginLifetimeScope())
        {
            var instance1 = container.GetInstance<TestClass>();
            instance1.GetDataByAccountNumber(1);
            var instance2 = container.GetInstance<TestClass>();
            instance2.GetDataByAccountNumber(2);
            // the container does return the same instance
            Assert.That(instance1, Is.EqualTo(instance2));
            // but the caching does not work
            Assert.That(instance2.CallerId, Is.EqualTo(1));
        }
    }
