    [Test]
    public void ShoulReturnHoonWhenValueDivisibleOnlyBy3()
    {
        var hoonGroup = new HoonGroup();
        string result = hoonGroup.Calculate(3);
        Assert.AreEqual("HOON", result);
    }
