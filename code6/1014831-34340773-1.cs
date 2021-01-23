        var userDbSet = new FakeDbSet<User>();
        userDbSet.Add(new User());
        userDbSet.Add(new User());
        
        var contextMock = new Mock<MySuperCoolDbContext>();
        contextMock.Setup(dbContext => dbContext.Users).Returns(userDbSet);
