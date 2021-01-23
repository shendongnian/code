    IBindingRoot.Bind<Configuration>().ToProvider<ConfigurationProvider>();
    IBIndingRoot.Bind<ISessionFactory>()
                .ToMethod(ctx => ctx.Kernel.Get<Configuration>().BuildSessionFactory())
                .InSingletonScope();
    public class ConfigurationProvider : IProvider<Configuration> 
    {
        private readonly IUserService userService;
        public ConfigurationProvider(IUserService userService)
        {
            this.userService = userService;
        }
        public object Create(IContext context)
        {
            if(this.userService.AuthenticatedUser == null)
                throw new InvalidOperationException("never ever try to use NHibernate before user is authenticated! this includes injection an ISessionFactory in any class! Postpone creationg of object tree until after authentication of user. This exception means you've produced buggy code!");
            return Fluently.Configure()
                .DataBase(MsSqlConfiguration.MsSql2008)
                    .ConnectionString(connectionBuilder => connectionBuilder.Is(... create the string...)
                ....
                .BuildConfiguration();
        }
    }
