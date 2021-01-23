    public static IContainer GetContainer()
    {            
        return new Container(container =>
        {
            container.For<IUserService>().Use<UserService>();
            container.For<IStringService>().Use<StringService>();
            container.For<IUserRepository>().Use<UserRepository>();                
        });
    }
