    [Fact]
    public void Correctly_Returns_Result()
    {
        // Arrange
        var validEmail = "test@test.com";
        var userThatMatches = new User { UserId = Guid.NewGuid(), Email = validEmail, IsLockedOut = false };
        var userThatDoesnotMatchByIsLockedOut = new User { UserId = Guid.NewGuid(), Email = validEmail, IsLockedOut = false };
        var userThatDoesnotMatchByEmail = new User { UserId = Guid.NewGuid(), Email = "Wrong Email", IsLockedOut = true };
        var aCollectionOfUsers = new List<User>
        {
            userThatMatches,
            userThatDoesnotMatchByIsLockedOut,
            userThatDoesnotMatchByEmail
        };
        var userRepositoryMock = new Mock<IGenericRepository<User>>();
        userRepositoryMock
            .Setup(it => it.Find(It.IsAny<Expression<Func<User, bool>>>()))
            .Returns<Expression<Func<User, bool>>>(predicate =>
            {
                return aCollectionOfUsers.Find(user => predicate.Compile()(user));
            });
            var sut = new GetUserByEmailQueryHandler(
                userRepositoryMock.Object);
        // Act
        var foundUser = sut.Handle(new GetUserByEmailQuery(validEmail));
        // Assert
        userRepositoryMock.Verify();
        Assert.Equal(userThatMatches.UserId, foundUser.UserId);
    }
