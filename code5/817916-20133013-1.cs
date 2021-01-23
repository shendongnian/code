    // Arrange
    var service = A.Fake<IService>(o => o.Strict()); // only allows configured calls
    A.CallTo(() => service.PostData("data")).DoesNothing(); // allow a specific call
    // Act
    testedObject.CallService("data");
    // Assert
    A.CallTo(() => service.PostData("data")).MustHaveHappened(Repeated.Exactly.Once);
