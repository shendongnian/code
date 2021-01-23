    [TestMethod]
    public void EnumerablesBehaveAsStreams()
    {
        // Arrange
        var container = new Container();
        container.Collection.Register<ILogger>(typeof(SqlLogger), typeof(FileLogger));
        IEnumerable<ILogger> loggers = container.GetAllInstances<ILogger>();
        // Act
        ILogger sqlLogger1 = loggers.First();
        ILogger sqlLogger2 = loggers.First();
        // Assert
        Assert.AreNotSame(sqlLogger1, sqlLogger2);
    }
