    [TestMethod]
    public void TestMethod1()
    {
        var res = ShiftRight(new [] { 1, 2, 3, 4, 5, 6 }, 2).ToArray();
        Assert.IsTrue(res.SequenceEqual(new[] { 5, 6, 1, 2, 3, 4 }));
    }
