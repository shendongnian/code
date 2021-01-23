    // Arrange
    var context = new Mock<Context>();
    var set = new Mock<DbSet<User>>();
    context.Setup(c => c.Set<User>()).Returns(set.Object);
    // Act
    // Assert
    set.Verify(s => s.Add(It.IsAny<User>()), Times.Once());
You don't really need to make verify anything except that Add() was called on the underlying DbSet. Doing your verify on the fact that the Entity state was modified is unnecessary. If you verify that Add() was called that should be enough as you can safely assume that EF is working properly. 
