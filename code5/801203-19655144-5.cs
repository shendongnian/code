    [HttpPost]
    public ActionResult Post(UserViewModel model)
    {
        UserIdentity user = MapUser(model);
        var userManager = new IdentityUserManager();
        userManager.Add(user);
        return View(new UserViewModel());
    }
