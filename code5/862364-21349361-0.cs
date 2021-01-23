    [Authorize]
    public ActionResult Index()
    {
        string loggedUser = User.Identity.Name;
        var model = db.AdresModel.Where(x => x.User.UserName == loggedUser).ToList();
        return View(model);
    }
