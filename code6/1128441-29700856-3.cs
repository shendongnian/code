    private void DoSet(int key, string value)
    {
    	throw new Exception();
    }
    
    [Test]
    public void verifiable_runs_callback()
    {
    	// Arrange
    	var mock = new Mock<IIndexed>();
    
    	mock.SetupSet(indexed => indexed[1] = "world").Callback<int, string>(DoSet).Verifiable();
    
    	var instance = mock.Object;
    
    	// Act
    
    	// Assert
    	Assert.That(() => instance[1] = "world", Throws.Exception);
    }
