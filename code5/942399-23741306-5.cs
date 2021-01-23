    [HttpGet]
    [AllowAnonymous]
    public ActionResult ViewImage(string id)
    {
        ApplicationUser user = m_DAL.Find<ApplicationUser>(x => x.UserName == User.Identity.Name);
        byte[] buffer = user.Picture;
        return File(buffer, "image/jpg", string.Format("{0}.jpg", user.UserName));
    }
