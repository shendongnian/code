    [TestMethod]
    public void When_Add_Called_Verify_AboveZero_Called_Too() {
        // Arrange
        var helperMock = new Mock<IHelpers>();    
        helperMock.Setup(x => x.AboveZero(It.IsAny<int>())).Returns(true);
        var calc = new Calculator(helperMock.Object);
        // Act
        var result = calc.Add(1, 2);
        // Assert
        helperMock.Verify(x => x.AboveZero(It.IsAny<int>())); // verify that AboveZero was called.
    }
