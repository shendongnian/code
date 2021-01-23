    // Arrange
    var service = A.Fake<IService>(o => o.Strict()); // only allows configured calls
    var expectedCall = A.CallTo(() => service.PostData("data"));
    expectedCall.DoesNothing(); // allow the call
    // Act
    testedObject.CallService("data");
    // Assert
    expectedCall.MustHaveHappened(Repeated.Exactly.Once);
