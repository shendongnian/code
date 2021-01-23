    public class TestUser : MyUser
    {
        //Known Test Scenario Properties and Methods as required
    }
    private static IContainer RegisterServices()
    {
        var builder = new ContainerBuilder();
        builder.RegisterApiControllers(System.Reflection.Assembly.GetAssembly(typeof(MyWeb.API.Startup)));
        builder.RegisterType<GlobalContext>().As<IGlobalContext>().SingleInstance();
        builder.RegisterType<TestUser>().As<MyUser>();
        builder.RegisterType<UserContext>().As<IUserContext>().InstancePerLifetimeScope();
        return builder.Build();
    }
