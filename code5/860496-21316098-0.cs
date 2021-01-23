    [TestMethod]
    public void UnitTest()
    {
        var mockService = new Mock<IService>();
    
        Func<IService> mockDelegate = () => mockService.Object;
    
        // The rest of the test
    }
