    public ActionResult Login()
    {
         // however you set the log in status
         return RedirectToAction("Details", "ProfileController", new { id = userId });
    }
