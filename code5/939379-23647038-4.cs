    Bind<IUnitOfWork>()
       .To<WebsiteDbContext>()
       .When(x => !HttpContext.Current.Request.IsAuthenticated)
       .InRequestScope()
       .WithConstructorArgument(
           "connectionString",
            ConfigurationManager.ConnectionStrings[ConnectionStringKeys.UnauthorisedUser]
               .ConnectionString);
    Bind<IUnitOfWork>()
        .To<WebsiteDbContext>()
        .When(x => HttpContext.Current.Request.IsAuthenticated)
        .InRequestScope()
        .WithConstructorArgument(
            "connectionString",
            ConfigurationManager.ConnectionStrings[ConnectionStringKeys.AuthorisedUser]
               .ConnectionString);
