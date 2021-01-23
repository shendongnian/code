	[Test]
	public void CheckService_WithTrueGetboolean_ShouldHave_PassStatus
	{
		//Arrange
		var logicCheckerMock = new Mock<ILogicChecker>();
		logicCheckerMock.Setup(x => x.Getboolean()).Returns(true);
		var service = new Service(logicCheckerMock.Object);
		//Act
		service.CheckService();
		//Assert
		Assert.That(service.Status, Is.EqualTo(Status.Pass));
	}
	[Test]
	public void CheckService_WithFalseGetboolean_ShouldHave_NotPassStatus
	{
		//Arrange
		var logicCheckerMock = new Mock<ILogicChecker>();
		logicCheckerMock.Setup(x => x.Getboolean()).Returns(false);
		var service = new Service(logicCheckerMock.Object);
		//Act
		service.CheckService();
		//Assert
		Assert.That(service.Status, Is.EqualTo(Status.NotPass));
	}
