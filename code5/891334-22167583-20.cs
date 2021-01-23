    [Test]
    public void ShoulReturnGroupWhenValueDivisibleOnlyBy5()
    {
        var hoonGroup = new HoonGroup();
        string result = hoonGroup.Calculate(5);
        Assert.AreEqual("Group", result);
    }
