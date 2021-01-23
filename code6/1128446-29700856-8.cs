    [Test]
    public void DoesNotExecuteCallback()
    {
    	// Arrange
    	var mock = new Mock<IIndexable>();
    
    	var called = false;
    	mock.SetupSet(m => m[It.IsAny<int>()] = It.IsAny<int>()).Callback<int,int>((x, y) => called = true);
    
    	var instance = mock.Object;
    
    	// Act
    	instance[1] = 2;
    
    	// Arrange
    	Assert.That(called, Is.False);
    }
