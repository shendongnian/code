    [UserPermissions(UserPermissions.ViewCars, UserPermissions.EditCars)]
    public ActionResult Index()
    {
        ViewBag.Title = "Home Page";
        return View();
    }
