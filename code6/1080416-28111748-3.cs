    [Test]
    public void TestGetFavourites()
    {
        var user = new ApplicationUser {Id = 1, UserName = "Test"};
        
        //Mock UserStore so our UserManager calls work
        var userStore = new Mock<IQueryableUserStore<ApplicationUser, string>>();
        userStore.Setup(m => m.FindByIdAsync(It.IsAny<int>)))
          .Returns(Task.FromResult(user));
        var userManager = new UserManager<ApplicationUser, int>(userStore.Object);
   
        // Mock our db context
        var users = new List<User>
        {
            new Api.User()
            {
                UserId = 1,
                UserName = "Test"
            }
        }.AsQueryable();
        var favourites = new List<Favourite>
        {
            new Favourite
            {
                UserId = 1
            }
        }.AsQueryable();
        var dbUsers = CreateMockDbSet(users);
        var dbFavourites = CreateMockDbSet(favourites);
        var dbContext = new Mock<MyContext>();
        dbContext.Setup(m => m.Favourites).Returns(dbFavourites.Object);
        dbContext.Setup(m => m.Users).Returns(dbUsers.Object);
            
        //You didn't specify how your controller got it's UserManager 
        // and db instances so I'm assuming constructor injection 
        var controller = new TestController(userManager, dbContext.Object);
        
        // Allows User.Identity.GetUserId() to work.
        var identity = new ClaimsIdentity();
        identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, "1"));
        controller.User = new ClaimsPrincipal(identity);
        // Run our tests
        var response = controller.GetFavourites();
            
        Assert.IsInstanceOf<OkNegotiatedContentResult<
          IQueryable<Favourite>>>(response);
        var responseObject = (OkNegotiatedContentResult<
          IQueryable<Favourite>>) response;
        Assert.That(responseObject.Content.Count(), Is.EqualTo(1));(response);
    }
