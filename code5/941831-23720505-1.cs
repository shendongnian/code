    //
    // POST: /Account/Login
    
    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public ActionResult Login(LoginModel model, string returnUrl)
    {
    	if (ModelState.IsValid && WebSecurity.Login(model.UserName, model.Password, persistCookie: model.RememberMe))
    	{
    
    		UsersContext dbu = new UsersContext();
    		UserProfile usr = dbu.UserProfiles.Where(u => u.UserName == model.UserName).First();
    
    		if (usr.FirstName == null) return RedirectToAction("Profile", "Account");
    
    		return RedirectToLocal(returnUrl);
    		
    	}
    
    	// If we got this far, something failed, redisplay form
    	ModelState.AddModelError("", "The user name or password provided is incorrect.");
    	return View(model);
    }
