    [TestMethod]
    public void Register()
    {
        // Arrange
        var userManager = new UserManager<ApplicationUser>(new TestUserStore<ApplicationUser>());
        var controller = new AccountController(userManager);
        controller.SetFakeControllerContext();
        // Modify the test to setup a mock IAuthenticationManager
        var mockAuthenticationManager = new Mock<IAuthenticationManager>();
        mockAuthenticationManager.Setup(am => am.SignOut());
        mockAuthenticationManager.Setup(am => am.SignIn());
        // Add it to the controller - this is why you have to make a public setter
        controller.AuthenticationManager = mockAuthenticationManager.Object;
        // Act
        var result =
            controller.Register(new RegisterViewModel
            {
                BirthDate = TestBirthDate,
                UserName = TestUser,
                Password = TestUserPassword,
                ConfirmPassword = TestUserPassword
            }).Result;
        // Assert
        Assert.IsNotNull(result);
        var addedUser = userManager.FindByName(TestUser);
        Assert.IsNotNull(addedUser);
        Assert.AreEqual(TestBirthDate, addedUser.BirthDate);
    }
