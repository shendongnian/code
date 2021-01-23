    // Existing context initialisation...
    var dbContext = new Mock<MyDbContext<IdentityUser>>();
    dbContext.Setup(x => x.Users).Returns(() => users);
    // NEW: Mock what / how Entry is going to return when called (i.e. return a user)
    dbContext.Setup(x => x.Entry(IsAnything)).Returns(() => users[0]);
