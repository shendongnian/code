    public ActionResult LogOff()
    {
        Request.Cookies.Remove("UserId");
        FormsAuthentication.SignOut();
        return RedirectToAction("LogOn", "LogOn");
    }
