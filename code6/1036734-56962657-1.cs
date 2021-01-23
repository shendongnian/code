    var relationalCommand = new Mock<IRelationalCommand>();
    relationalCommand.Setup(m => m.ExecuteNonQuery(It.IsAny<IRelationalConnection>(), It.IsAny<IReadOnlyDictionary<string, object>>())).Returns(() => expectedResult);
    
    var rawSqlCommand = new Mock<RawSqlCommand>(MockBehavior.Strict, relationalCommand.Object, new Dictionary<string, object>());
    rawSqlCommand.Setup(m => m.RelationalCommand).Returns(() => relationalCommand.Object);
    rawSqlCommand.Setup(m => m.ParameterValues).Returns(new Dictionary<string, object>());
    
    var rawSqlCommandBuilder = new Mock<IRawSqlCommandBuilder>();
    rawSqlCommandBuilder.Setup(m => m.Build(It.IsAny<string>(),  It.IsAny<IEnumerable<object>>())).Returns(rawSqlCommand.Object);
    
    var databaseFacade = new Mock<DatabaseFacade>(MockBehavior.Strict, _dbContextToMock);
    databaseFacade.As<IInfrastructure<IServiceProvider>>().Setup(m => m.Instance.GetService(It.Is<Type>(t => t == typeof(IConcurrencyDetector)))).Returns(new Mock<IConcurrencyDetector>().Object);
    databaseFacade.As<IInfrastructure<IServiceProvider>>().Setup(m => m.Instance.GetService(It.Is<Type>(t => t == typeof(IRawSqlCommandBuilder)))).Returns(rawSqlCommandBuilder.Object);
    databaseFacade.As<IInfrastructure<IServiceProvider>>().Setup(m => m.Instance.GetService(It.Is<Type>(t => t == typeof(IRelationalConnection)))).Returns(new Mock<IRelationalConnection>().Object);
                
    _dbContextMock.Setup(m => m.Database).Returns(databaseFacade.Object);
