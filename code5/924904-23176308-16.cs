    [TestFixture]
    public class ControllerTests
    {
      [Test]
      public void KeyPressed_WhenAIsPressed_ShouldCallStateAlteringMethod()
      {
        // Arrange
        var stub = new StubGameState();
        var controller = new Controller(stub);
    
        // Act
        controller.KeyPressed("A");
    
        // Assert
        Assert.IsTrue(stub.WasStateAlteringMethodCalled);
      }
      [Test]
      public void KeyPressed_WhenBIsPressed_ShouldNotCallStateAlteringMethod()
      {
        // Arrange
        var stub = new StubGameState();
        var controller = new Controller(stub);
        
        // Act
        controller.KeyPressed("B");
        
        // Assert
        Assert.IsFalse(stub.WasStateAlteringMethodCalled); 
      }
    }
