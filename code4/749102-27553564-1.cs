    [TestMethod]
    [DataSource("Namespace.UnitTest1.Stuff")]
    public void TestMethod1()
    {
        var number = this.TestContext.GetRuntimeDataSourceObject<int>();
    
        Assert.IsNotNull(number);
    }
