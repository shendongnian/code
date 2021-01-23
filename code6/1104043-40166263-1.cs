    // GET: Main
    public ActionResult Index()
    {
        ApplicationUser sessionuser = db.Users.Find(User.Identity.GetUserId());
        Session.Add("UserName", sessionuser.UserName);
        return View();
    }
