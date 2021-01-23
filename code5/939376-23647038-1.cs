    Bind<IUnitOfWork>()
       .To<WebsiteDbContext>()
       .InRequestScope()
       .When(x => !HttpContext.Current.Request.IsAuthenticated)
       .WithConstructorArgument(
           "connectionString",
            ConfigurationManager.ConnectionStrings[ConnectionStringKeys.UnauthorisedUser]
               .ConnectionString);
    Bind<IUnitOfWork>()
        .To<WebsiteDbContext>()
        .InRequestScope()
        .When(x => HttpContext.Current.Request.IsAuthenticated)
        .WithConstructorArgument(
            "connectionString",
            ConfigurationManager.ConnectionStrings[ConnectionStringKeys.AuthorisedUser]
               .ConnectionString);
