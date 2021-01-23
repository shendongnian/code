    private Task<int> val = 0;
    [TestInitialize]
    public void TestInitializeMethod()
    {
        val = TestInitializeMethodAsync();
    }
    private async Task<int> TestInitializeMethodAsync()
    {
        var result = await LongRunningMethod();
        return 10;
    }
    [TestMethod]
    public async Task TestMehod2()
    {
        Assert.AreEqual(10, await val);
    }
