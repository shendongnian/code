    [Test]
    public void NamedAndUnnamedTest()
    {
        Assert.AreEqual("Only value1 was supplied", DummyMethod(value1: 1));
        Assert.AreEqual("Only value1 was supplied", DummyMethod(1));
        Assert.AreEqual("Only value2 was supplied", DummyMethod(value2: 1));
        Assert.AreEqual("Both arguments were supplied", DummyMethod(1, 2));
    }
    private string DummyMethod(int value1 = 0, int value2 = 0)
    {
        if (value1 != 0 && value2 != 0)
            return "Both arguments were supplied";
        if (value1 == 0)
            return "Only value2 was supplied";
        return "Only value1 was supplied";
    }
