    using (ShimsContext.Create())
    {
        var paymentServiceMock = new Mock<IPaymentService>();
        paymentService.Setup(x=>x.Pay(Moq.It.IsAny<int>).Returns(999);
        // Shim DateTime.Now to return a fixed date:
        System.Fakes.ShimDateTime.StaticContext.Store.CurrentStoreIdGet = () =>  { 1 };
        // Act
        var result = paymentService.Object.Pay(123);
    }
