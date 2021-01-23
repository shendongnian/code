    [Test]
    [TestCase("4242424242424242")
    public void ShouldBeValid(string cardNumber)
    {
        Assert.IsTrue(new LuhnCardValidator().IsCardValid(cardNumber));
    }
