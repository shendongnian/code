    [Authorize]
    public ActionResult GetCurrentUser()
    {
        var user = UserManager.FindById(User.Identity.GetUserId());
        var model = new UserPostWrapper { UserInfoObject = user};
        return View(model);
    }
