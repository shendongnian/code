    [ChildActionOnly]
    public ActionResult UserProfile(string user)
    {
        ViewBag.UserName = user;
        return PartialView();
    }
