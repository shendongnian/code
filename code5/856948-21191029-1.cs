    private A _a;
    [TestInitialize]
    public void Initialize()
    {
        _a = new B();
    }
    [TestMethod]
    public void ShouldReturn3WhenICallMustReturn3()
    {
        Assert.AreEqual(3, _a.MustReturn3());
    }
