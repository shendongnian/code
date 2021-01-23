    [Test]
    public void TempTest()
    {
        string data = new AsyncTest().DoTest().Result;
        Assert.IsNotNull( data );
        Assert.IsNull( data );
    }
