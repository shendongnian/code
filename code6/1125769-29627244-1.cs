    private static IContainer RegisterServices()
    {
        var builder = new ContainerBuilder();
        builder.RegisterApiControllers(System.Reflection.Assembly.GetAssembly(typeof(MyWeb.API.Startup)));
        builder.RegisterType<GlobalContext>().As<IGlobalContext>().SingleInstance();
        builder.Register(c => c.Resolve<IGlobalContext>().User(
            "MyTestUser")
            ).As<MyUser>();
        builder.RegisterType<UserContext>().As<IUserContext>().InstancePerLifetimeScope();
        return builder.Build();
    }
