    // Counters to verify call order
    int callCount = 0;
    int addUser = 0;
    int saveChanges = 0;
    // use Moq to create a mock IDbContext.
    var mockContext = new Mock<IDbContext>();
    // Register callbacks for the mocked methods to increment our counters.
    mockContext.Setup(x => x.Users.Add(It.IsAny<User>())).Callback(() => addUser = callCount++);
    mockContext.Setup(x => x.SaveChanges()).Callback(() => saveChanges = callCount++);
    // Create the command, providing it the mocked IDbContext and execute it
    var command = new AddUserCommand(mockContext.Object);
    command.Execute();
    // Check that each method was only called once.
    mockContext.Verify(x => x.Users.Add(It.IsAny<User>()), Times.Once());
    mockContext.Verify(x => x.SaveChanges(), Times.Once());
    // check the counters to confirm the call order.
    Assert.AreEqual(0, addUser);
    Assert.AreEqual(1, saveChanges);
