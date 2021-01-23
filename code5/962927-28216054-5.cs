        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
        {
            var repository = System.Web.Http.GlobalConfiguration.Configuration.DependencyResolver
                                .GetService(typeof(Data.Repositories.UserRepository)) as Data.Repositories.UserRepository;
            var manager = new ApplicationUserManager(repository);
    ...
