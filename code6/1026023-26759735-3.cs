    public class TestUserManager : UserManager<TestUser>
    {
        public TestUserManager() : base(new ApplicationUserStore(new TestContext()))
        {
        }
    }
