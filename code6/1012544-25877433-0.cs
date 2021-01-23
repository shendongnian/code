    [TestMethod]
    public void NoPrivateConstructors()
    {
        Assert.IsFalse(typeof(Logger).GetConstructors(/* binding flags... */).Any());
    }
