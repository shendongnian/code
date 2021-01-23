    [AllowAnonymous]
    public FileResult GetLogoImage()
    {
        var logo = _adminPractice.GetAll().FirstOrDefault();
        if (logo != null)
        {
            return new FileContentResult(logo.PracticeLogo, "image/jpeg");
        }
        else
        {
            return new FilePathResult(HttpContext.Server.MapPath("~/Content/images/practicelogo.jpeg"), "image/jpeg");
        }
    }
