    [TestCase(3)]
    [TestCase(6)]
    [TestCase(99)]
    public void ShoulReturnHoonWhenValueDivisibleOnlyBy3(int value)
    {
        var hoonGroup = new HoonGroup();
        string result = hoonGroup.Calculate(value);
        Assert.AreEqual("HOON", result);
    }
