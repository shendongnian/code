    [Test]
    public void ShoulReturnNullWhenValueIsNotDivisibleBy3Or5()
    {
        var hoonGroup = new HoonGroup();
        string result = hoonGroup.Calculate(5);
        Assert.IsNull(result);
    }
