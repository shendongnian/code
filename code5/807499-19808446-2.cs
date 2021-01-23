    [Test]
    public void GetInstance_SameType_HasSameCachePolicy()
    {
        Container container = ConfigureContainer();
        using (container.BeginLifetimeScope())
        {
            var a1 = container.GetInstance<A>();
            var a2 = container.GetInstance<A>();
            Assert.AreEqual(a1.CachePolicy, a2.CachePolicy);
        }
    }
    [Test]
    public void GetInstance_DifferentType_HasDifferentCachePolicy()
    {
        Container container = ConfigureContainer();
        using (container.BeginLifetimeScope())
        {
            var a1 = container.GetInstance<A>();
            var b1 = container.GetInstance<B>();
            Assert.AreNotEqual(a1.CachePolicy, b1.CachePolicy);
        }
    }
