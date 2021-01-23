    [Test]
    public void ShouldPresentCardFailedMessage()
    {
        var mockCardValidator = new Mock<ICardValidator>();
        mockCardValidator.Setup(x => x.IsCardValid(It.IsAny<string>()).Returns(false);
        var validationSummary = new ValidationSummary(mockCardValidator.Object);
        var errors = validationSummary.GetErrors();
        Assert.Contains("Credit Card Number is Invalid", errors);
    }
