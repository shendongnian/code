    // arrange
    var objectUnderTest = ...
    var mockPluginExecContext = new MockedPluginExecutionContext();
    var mockProvider = Substitute.For<IServiceProvider>();
    mockProvider.GetService<IPluginExecutionContext>.Returns(mockPluginExecContext);
    // act
    objectUnderTest.Execute(mockProvider);
    // assert
    Assert.IsTrue(...);
