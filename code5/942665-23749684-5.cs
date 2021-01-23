    [TestMethod]
    public void TestMethod1()
    {
        Assert.AreEqual(2, Stuff.GetParent(4));
        Assert.AreEqual(2, Stuff.GetParent(5));
        Assert.AreEqual(6, Stuff.GetParent(13));
        Assert.AreEqual(null, Stuff.GetParent(1));
    }
