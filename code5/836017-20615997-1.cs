    var dependencyMock = new Mock<IDependency>();
    dependencyMock.Setup(d => d.Something(bar)); // setup interaction
    var sut = new Sut(dependencyMock.Object);
    sut.Excercise(foo);
    dependencyMock.VerifyAll(); // verify sut interacted with dependency
