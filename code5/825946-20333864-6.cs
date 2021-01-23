    // Arrange:
    var tokenManagerMock = Mock.Of<TokenManager>();
    var subscriber = new Subscriber {TokenManager = tokenManagerMock};
    // Act:
    subscriber.Subscribe(It.IsAny<string>(),
    	It.IsAny<string>(),
    	It.IsAny<string>());
    // Assert:
    Mock.Get(tokenManagerMock).Verify(x =>
    		x.GetToken(It.IsAny<string>(), It.IsAny<bool>()), Times.AtLeastOnce);
----
