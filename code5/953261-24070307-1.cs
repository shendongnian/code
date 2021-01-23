    // Arrange
    int key = 1;    
    var exceptionRaised = false;
    board.Add(key, "X");
    // Act
    try {
        board.Add(key, "X");
    }
    catch(InvalidOperationException ex) {
        exceptionRaised = true;
    }
    // Assert
    Assert.That(exceptionRaised, Is.True);
