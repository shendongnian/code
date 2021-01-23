    public void CreateUserTest()
    {
        var mockUserProvider = new Mock<UserProvider>(MockBehavior.Loose);
    //GetUserRequestObject is local method to set data
         mockUserProvider.
            Setup(u => u.CreateUser(Is.Any<User>(), ""))
            .Returns(new UserResponseObject { uid = "123", uri = userUri }).Verifiable();
         var userProvider = mockUserProvider.Object.CreateUser(Is.Any<User>(), "");
         mockUserProvider.Verify(u => u.CreateUser(Is.Any<User>(), ""));
    }
