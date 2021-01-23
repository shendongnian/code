    // Arrange
    var mockMyClass = new Mock<MyClass>();
    mockMyClass.Object.ViewMode = ViewMode.New; // I've made an assumption or two here ...
    mockMyClass.Protected().Setup<bool>("IsSavable").Returns(true);
    // Act!
    var result = (bool)mockMyClass.Object.GetType().InvokeMember("IsExecutable",
        BindingFlags.InvokeMethod | BindingFlags.NonPublic | BindingFlags.Instance,
        null,
        mockMyClass.Object,
        null);
    // Assert
    Assert.IsTrue(result);
    mockMyClass.Protected().Verify<bool>("IsSavable", Times.Once());
