    [TestMethod]
    public void TestSeries()
    {
        int k = 1;
        int p = 1;
        BigRational expected = 1;
        Assert.AreEqual(expected, Program.Series(k, p));
        k = 2;
        p = 1;
        expected += 1;
        Assert.AreEqual(expected, Program.Series(k, p));
        k = 3;
        p = 1;
        expected += (BigRational)1 / (BigRational)2;
        Assert.AreEqual(expected, Program.Series(k, p));
        k = 1;
        p = 2;
        expected = 1;
        Assert.AreEqual(expected, Program.Series(k, p));
        k = 2;
        p = 2;
        expected += 2;
        Assert.AreEqual(expected, Program.Series(k, p));
    }
