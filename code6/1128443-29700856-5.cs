    [Test]
    public void mocked_set_fails_assert()
    {
        // Arrange
        var mock = new Mock<IIndexed>();
        mock.SetupSet(indexed => indexed[1] = "world").Throws<Exception>();
    
        var instance = mock.Object;
    
        // Act
        
        // Assert
        Assert.That(() => instance[1] = "world", Throws.Exception);
    }
