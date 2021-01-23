    public ActionResult Validate(string username, string password)
    {
         // Do Stuff, then call your next view and pass model.
         return RedirectToAction("Account");
    }
