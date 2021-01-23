    [Authorize(Roles = "Admin")]
    public ActionResult Index()
    {
        var model = db.UserProfiles.ToList();
        var rolesCollection = new List<string> {"Null", "Manager", "Agent"};
        ViewBag.Roles = new SelectList(rolesCollection);
        return View(model);
    }
