    private int val = 0;
    [TestInitialize]
    public void TestMehod1()
    {
        Task<object> result = await LongRunningMethod();
        result.Wait();
        val = 10;
    }
    [TestMethod]
    public void  TestMehod2()
    {
        Assert.AreEqual(10, val);
    }
