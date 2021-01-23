    Mock<YourBaseClass> baseClassMock = new Mock<YourBaseClass>();
    baseClassMock.Protected().Setup<bool>(
        "ExecuteInteraction", 
         ItExpr.IsAny<string>(),
         ItExpr.IsAny<Action<object>>(),
         ItExpr.IsAny<object[]>())
    .Returns(true);
