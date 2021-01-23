    [HttpGet] 
    [ValidateAntiForgeryToken]
    public ActionResult LogOff()
    {
         AuthenticationManager.SignOut();
         return RedirectToAction("Login", "Account");
    }
