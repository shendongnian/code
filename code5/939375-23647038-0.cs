    Bind<IUnitOfWork>()
       .To<WebsiteDbContext>()
       .InRequestScope()
       .WithConstructorArgument(
           "connectionString",
            ConfigurationManager.ConnectionStrings[ConnectionStringKeys.UnauthorisedUser]
               .ConnectionString)
        .When(x => !HttpContext.Request.IsAuthenticated);
    Bind<IUnitOfWork>()
        .To<WebsiteDbContext>()
        .InRequestScope()
        .WithConstructorArgument(
            "connectionString",
            ConfigurationManager.ConnectionStrings[ConnectionStringKeys.AuthorisedUser]
               .ConnectionString)
         .When(x => HttpContext.Request.IsAuthenticated);
