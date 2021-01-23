    [TestMethod]
    public void UserServiceTest()
    {
            //Initialize your Mock Data
            var testDataUser = new List<Users> 
            { 
                new User{
                                    ID = 1,
                                    Name = "MockUser"
                }
            }.AsQueryable();
             //Initialize the Mock DbSet
            var mockSetUser = new Mock<DbSet<User>>();
            mockSetUser.As<IQueryable<User>>().Setup(m => m.Provider).Returns(testDataUser. .Provider);
            mockSetUser.As<IQueryable<User>>().Setup(m => m.Expression).Returns(testDataUser .Expression);
            mockSetUser.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(testDataUser .ElementType);
            mockSetUser.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(testDataUser .GetEnumerator());
             //Initialize the mock Context
            var mockContext = new Mock<UserContext>();
            //Return the mock DbSet via the mock context
            mockContext.Setup(c => c.Users).Returns(mockSetUser.Object);
            //Create the service and inject the mock context
            var userService = new UserService(mockContext.Object)
            
            //Test your context via the service
            var user = userService.GetUserByID(1);
            Assert.AreEqual("MockUser", user.Name);
    }
