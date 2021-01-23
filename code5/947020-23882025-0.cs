    public void CreateUserTest()
    {
        var mockUserProvider = new Mock<UserProvider>(MockBehavior.Loose);
    //GetUserRequestObject is local method to set data
         var user = GetUserRequestObject();
         mockUserProvider.
            Setup(u => u.CreateUser(user, ""))
            .Returns(new UserResponseObject { uid = "123", uri = userUri }).Verifiable();
         var userProvider = mockUserProvider.Object.CreateUser(user, "");
         mockUserProvider.Verify(u => u.CreateUser(user, ""));
    }
