    [SetUp]
    public void Setup()
    {
        Mocker = GetMoqer();
    }
    AutoMoqer GetMoqer() 
    { 
        // configure base Mocker 
        return new AutoMoqer();
    }
    [Test]
    public void TestWithDifferentInstances()
    {
        var s1 = Mocker.ResolveMock<IService>();
        var otherMocker = GetMoqer();
        var s2 = otherMocker.ResolveMock<IService>();
        Assert.That(s1, Is.Not.SameAs(s2));
    }
