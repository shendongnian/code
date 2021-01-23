    using (var scope = System.Web.Http.GlobalConfiguration.Configuration.DependencyResolver.BeginScope())
    {
        var _userService = scope.GetService(typeof(IUserService)) as IUserService;
        //your code to use the service
    }
