    var mockUserManager = new Mock<IUserManager>();
    // Configure the User to be returned by calling GetByCredentials
    mockUserManager
        .Setup(x => x.GetByCredentials(It.IsAny<int>(), It.IsAny<Account>())
        .Returns(User.CreateUser(1, "foo", "username", new Account());
    
    var controller = new MyController(mockUserManager.Object);
    
    var user = controller.GetByCredentials("username", "password");
    Assert.NotNull(user);
    mockUserManager.Verify(x => x.GetByCredentials(It.IsAny<int>(), It.IsAny<Account>(), Times.Once());
