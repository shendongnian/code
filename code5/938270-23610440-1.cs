    [TestMethod]
    public void ResetAllProperties_AssertWasCalled()
    {
        // Arrange
        var engine = new Engine
        {
            Location = new EngineLocation { CustomerName = "Dzenan" },
            Manufacturing = new EngineManufacturing { EntryDate = DateTime.Today }
        };
        var status = new FirstEngineStatus(engine);
        // Act
        status.ResetAllProperties();
        // Assert
        Assert.IsNull(engine.Location.CustomerName);
        Assert.IsNull(engine.Manufacturing.EntryDate);
    }
