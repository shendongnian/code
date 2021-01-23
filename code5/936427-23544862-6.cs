    [Test]
    public void ShouldPresentCardFailedMessage()
    {
        var mockCardValidator = new Mock<ICardValidator>();
        mockCardValidator.Setup(x => x.IsCardValid(It.IsAny<string>()).Returns(false);
        var validationSummary = new ValidationSummary(mockCardValidator.Object);
        validationSummary.ValidateThePage(...);
        var errors = validationSummary.GetErrors();
        Assert.IsTrue(errors.Any(x => x.Message == "Credit card number is not valid"));
    }
