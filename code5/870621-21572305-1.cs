    [TestMethod]
    public void SomeMethod_ShouldAddSubStoreCode_ThroughService()
    {
        // Arrange:
        // - create dependency and create instance of system under test (sut)
        // - we don't need mock.Setup here; verification is made at the end
        var mockStoreCodeService = new Mock<IStoreCodeService>();
        var sut = new SomeComponent(mockStoreCodeService);
  
        // Act: execute method on sut
        sut.SomeMethod();
        // Assert: verify expectations (that call has been made to service)
        mockStoreCodeService.Verify(m => m.AddSubStoreCode(It.IsAny<SubStore>));
    }
