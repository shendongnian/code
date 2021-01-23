    [Authorize(Roles="Admin")]
    public ActionResult Register()
    {
        using (var ctx = new UsersContext())
        {
            var model = new UserProfilesRegisterModel();
            model.UserProfiles = ctx.UserProfiles.ToList();
            return View(model);
        }
    }
