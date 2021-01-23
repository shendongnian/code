    [TestFixtureSetup]
    public void Init()
    {
        Fluently.Configure()
                .Database(/* examples here */)
                .Mappings(...)
                .BuildSessionFactory();
    }
    [TestFixtureTeardown]
    public void Cleanup()
    {
        // tear down the session here...
    }
    [Test]
    public void GetActiveContainer_Returns_Expected_Containers()
    {
        var sut = new ContainerRepository();
        var list = sut.GetActiveContainers().ToList();
        Assert.IsTrue(list.Count > 0);
    }
