    public class BaseTest
    {
        protected static User CurrentUser;
        protected static IList<string> Roles;
        public BaseTest()
        {
            var email = "unit@test.com";
            CurrentUser = new User
            {
                FullName = "Unit Tester",
                Email = email,
                UserName = email,
                PhoneNumber = "123456",
                Organization = new Organization
                {
                    Name = "Test Organization"
                }
            };
            Roles = new List<string>
            {
                "Administrator"
            };
        }
        protected void InitializeApiController(ApiController apiController)
        {
            //Init fake controller Http and Identity data
            var config = new HttpConfiguration();
            var request = new HttpRequestMessage();
            var routeData = new HttpRouteData(new HttpRoute(""));
            apiController.ControllerContext = new HttpControllerContext(config, routeData, request)
            {
                Configuration = config
            };
            apiController.User = new GenericPrincipal(new GenericIdentity(""), new[] { "" });
            //Initialize Mocks
            var appUserMgrMock = GetMockedApplicationUserManager();
            var appSignInMgr = GetMockedApplicationSignInManager(appUserMgrMock);
            var appDbContext = GetMockedApplicationDbContext();
            //Configure HttpContext.Current.GetOwinContext to return mocks
            var owin = new OwinContext();
            owin.Set(appUserMgrMock.Object);
            owin.Set(appSignInMgr.Object);
            owin.Set(appDbContext.Object);
            HttpContext.Current = new HttpContext(new HttpRequest(null, "http://test.com", null), new HttpResponse(null));
            HttpContext.Current.Items["owin.Environment"] = owin.Environment;
        }
        private static Mock<ApplicationSignInManager> GetMockedApplicationSignInManager(Mock<ApplicationUserManager> appUserMgrMock)
        {
            var authMgr = new Mock<Microsoft.Owin.Security.IAuthenticationManager>();
            var appSignInMgr = new Mock<ApplicationSignInManager>(appUserMgrMock.Object, authMgr.Object);
            return appSignInMgr;
        }
        private Mock<ApplicationUserManager> GetMockedApplicationUserManager()
        {
            var userStore = new Mock<IUserStore<User>>();
            var appUserMgr = new Mock<ApplicationUserManager>(userStore.Object);
            appUserMgr.Setup(aum => aum.FindByIdAsync(It.IsAny<string>())).ReturnsAsync(CurrentUser);
            appUserMgr.Setup(aum => aum.GetRolesAsync(It.IsAny<string>())).ReturnsAsync(Roles);
            return appUserMgr;
        }
        private static Mock<ApplicationDbContext> GetMockedApplicationDbContext()
        {
            var dbContext = new Mock<ApplicationDbContext>();
            dbContext.Setup(dbc => dbc.Users).Returns(MockedUsersDbSet);
            return dbContext;
        }
        private static IDbSet<User> MockedUsersDbSet()
        {
            var users = new List<User>
            {
                CurrentUser,
                new User
                {
                    FullName = "Testguy #1",
                    Email = "test@guy1.com",
                    UserName = "test@guy1.com",
                    PhoneNumber = "123456",
                    Organization = new Organization
                    {
                        Name = "Test Organization"
                    }
                }
            }.AsQueryable();
            var usersMock = new Mock<DbSet<User>>();
            usersMock.As<IQueryable<User>>().Setup(m => m.Provider).Returns(users.Provider);
            usersMock.As<IQueryable<User>>().Setup(m => m.Expression).Returns(users.Expression);
            usersMock.As<IQueryable<User>>().Setup(m => m.ElementType).Returns(users.ElementType);
            usersMock.As<IQueryable<User>>().Setup(m => m.GetEnumerator()).Returns(users.GetEnumerator);
            return usersMock.Object;
        }
    }
