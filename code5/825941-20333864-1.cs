    [Test]
    public void Subscribe_TokenIsValidated_GetTokenIsCalledOnce()
    {
        // Arrange:
        var tokenManagerMock = Mock.Of<TokenManager>();
        var tokenValidator = Mock.Of<TokenValidator>(x => x.Validate(It.IsAny<Token>()) == true);
        var subscriber = new Subscriber {TokenManager = tokenManagerMock, TokenValidator = tokenValidator};
        // Act:
        subscriber.Subscribe(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>());
        // Assert:
        Mock.Get(tokenManagerMock).Verify(x => x.GetToken(It.IsAny<string>(), It.IsAny<bool>()), Times.Once);
    }
