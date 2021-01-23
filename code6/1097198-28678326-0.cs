    private void RegisterDependencyResolver()
    {
         kernel
         .Bind<ISession>()
         .To<SessionService>()
         .InRequestScope()
         .WithConstructorArgument(
             "context", 
             ninjectContext => new HttpContextWrapper(HttpContext.Current)
          );
         DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
    }
