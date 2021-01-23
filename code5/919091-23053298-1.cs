    [Test]
    public void OpenEquipmentOpensAddedEquipment()
    {
        // Standard Arrange
        SetupTesterApp(ConstForNormalOperation);
        
        // Test-Specific setups (possibly overriding the above factory setup)
        mockTestEquipment.Setup(_ => _.AnotherMethod()).Returns(OverriddenValue);
    
        // Act
        Assert.DoesNotThrow(() => t.OpenEquipment());
    
        // Standard Asserts
        VerifyStandardHappyScenario();
        // Specific Asserts and Verifies to this test
        mock.Verify(eq => eq.Open(), Times.Exactly(1));
    }
