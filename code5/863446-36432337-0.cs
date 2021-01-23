    // Arrange
        var expectedParamName = "param";
        bool exceptionThrown = false;
        // Act
        try
        {
        	new Sut(null);
        }
        // Assert
        catch (ArgumentNullException ex)
        {
        	exceptionThrown = true;
        	Assert.AreEqual(expectedParamName, ex.ParamName);
        }
        Assert.That(exceptionThrown);
