    Func<IUserService> _userServiceFactory;
    public HomeController(Func<IUserService> userServiceFactory)
    {
        _userServiceFactory= userServiceFactory;
    }
    public ActionResult SomeMethod()
    {
        IUserService userService = _userServiceFactory();
        userService.DoSomething();
       return View();
    }
    public ActionResult SomeOtherMethod()
    {
        //I don't use the service here
       return View();
    }
