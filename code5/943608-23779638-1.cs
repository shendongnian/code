    [Test]
    public void When_Paying_Should_Return_PaymentId
    {
        // Arrange
        var storeMock = new Mock<IStore>();
        storeMock.SetupGet(s => s.CurrentStoreId).Returns(999);
        var paymentService = new PaymentService(storeMock.Object);
        // Act
        var result = paymentService.Pay(123);
        // Asserts and rest of the test goes here
    }
