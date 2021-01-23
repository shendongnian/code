    public ActionResult PlayerDisplayStats()
    {
        var user = _instance.Users.GetUserSkills( WebSecurity.CurrentUserName);
        var userModel = new UserModel(user);
        return PartialView(userModel);
    }
