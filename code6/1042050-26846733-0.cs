    public ActionResult _LoginPartial()
    {
        ApplicationUser user = null;
        ManageUserViewModel model = null;
        string userID = User.Identity.GetUserId() ?? String.Empty;
        if (!String.IsNullOrEmpty(userID))
        {
            user = UserManager.FindById(userID);
            model = new ManageUserViewModel();
            model.IsAdmin = user.IsAdmin;
        }
        return PartialView(model);
    }
