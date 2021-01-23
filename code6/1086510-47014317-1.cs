    // Arrange
	var mockMultiplexer = new Mock<IConnectionMultiplexer>();
	
	mockMultiplexer.Setup(_ => _.IsConnected).Returns(false);
	var mockDatabase = new Mock<IDatabase>();
	
	mockMultiplexer
        .Setup(_ => _.GetDatabase(It.IsAny<int>(), It.IsAny<object>()))
        .Returns(mockDatabase.Object);
	var cacheHandler = new RedisCacheHandler(mockMultiplexer.Object);
	
	// Act
	cacheHandler.DoYourJob();
	
	
	// Assert
	// your tests
