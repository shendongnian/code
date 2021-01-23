    [Test]
    public void NamedAndUnnamedTest()
    {
        Assert.AreEqual(1, DummyMethod(value: 1));
        Assert.AreEqual(1, DummyMethod(1));
    }
    private int DummyMethod(int value)
    {
        return value;
    }
