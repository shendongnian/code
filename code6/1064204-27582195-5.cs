    public class WebsiteRegistry : Registry
    {
        public WebsiteRegistry()
        {
            this.For<IUserService>().Use<UserService>();
            this.For<IStringService>().Use<StringService>();
            this.For<IUserRepository>().Use<UserRepository>();         
        }
    }
