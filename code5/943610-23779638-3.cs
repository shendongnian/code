    [Test]
    public void When_Paying_Should_Return_PaymentId
    {
        // Arrange
        var storeMock = new Mock<IStore>();
        storeMock.Setup(s => s.CurrentStoreId).Returns(999);
        var paymentService = new PaymentService(storeMock.Object);
        // Act
        var result = paymentService.Pay(123);
        storeMock.Verify();
        // Asserts and rest of the test goes here        
    }
