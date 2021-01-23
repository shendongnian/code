    [Authorize]
    public ActionResult Index()
    {
        string username = User.Identity.Name;
        ...
    }
