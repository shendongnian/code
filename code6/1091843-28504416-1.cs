    [TestMethod]
    public void TestMaxBits()
    {
        long maxMillis = (1L << 42) - 1;
        DateTime maxDate = DateTimeHelper.FromMillisecondsSinceUnixEpoch(maxMillis);
        Assert.Greater(maxDate, new DateTime(2100, 1, 1, 0, 0, 0));
    }
