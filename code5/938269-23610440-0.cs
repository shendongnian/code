    [TestMethod]
    public void ResetAllProperties_AssertWasCalled()
    {
        var location = MockRepository.GeneratePartialMock<EngineLocation>();
        var manufacturing = MockRepository.GeneratePartialMock<EngineManufacturing>();
        // Arrange
        var engine = new Engine
        {
            Location = location,
            Manufacturing = manufacturing
        };
        var status = new FirstEngineStatus(engine);
        location.Expect(action => action.ResetAllProperties());
        manufacturing.Expect(action => action.ResetAllProperties());
        // Act
        status.ResetAllProperties();
        // Assert
        location.VerifyAllExpectations();
        manufacturing.VerifyAllExpectations();
    }
