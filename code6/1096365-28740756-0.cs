    public void Can_Create_User()
    {
        //Arrange
        var dummyUser = new ApplicationUser() { UserName = "PinkWarrior", Email = "PinkWarrior@PinkWarrior.com" };
        var mockStore = new Mock<IUserStore<ApplicationUser>>();
        var userManager = new UserManager<ApplicationUser>(mockStore.Object);
        mockStore.Setup(x => x.CreateAsync(dummyUser))
                    .Returns(Task.FromResult(IdentityResult.Success));
        mockStore.Setup(x => x.FindByNameAsync(dummyUser.UserName))
                    .Returns(Task.FromResult(dummyUser));
        //Act
        Task<IdentityResult> tt = (Task<IdentityResult>)mockStore.Object.CreateAsync(dummyUser);
        var user = userManager.FindByName("PinkWarrior");
        //Assert
        Assert.AreEqual("PinkWarrior", user.UserName);
    }
