    public ActionResult Index()
    {
        CurrentUserId = db.Users.Single(u => u.Username == User.Identity.Name);
        return View(db.Contacts.Where(c => c.UserId == CurrentUserId).ToList());
    }
