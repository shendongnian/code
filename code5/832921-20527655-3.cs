    public ActionResult Index()
    {
        User current = db.Users.Single(u => u.Username == User.Identity.Name);
        return View(db.Contacts.Where(c => c.UserId == current.Id).ToList());
    }
