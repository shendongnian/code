    [Test]
    public void DoesExecuteCallback()
    {
    	// Arrange
    	var mock = new Mock<IIndexable>();
    
    	var called = false;
    	mock.SetupSet(m => m[1] = 2).Callback<int,int>((x, y) => called = true);
    
    	var instance = mock.Object;
    
    	// Act
    	instance[1] = 2;
    
    	// Arrange
    	Assert.That(called, Is.True);
    }
