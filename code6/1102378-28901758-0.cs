    //
    // GET: /Account/Login
    [AllowAnonymous]
    public ActionResult Login(string returnUrl)
    {
        ViewBag.ReturnUrl = returnUrl;
        return View();
    }
    // POST: /Account/Login
    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Login(LoginViewModel model, 
    string returnUrl = "")
    {
        if (!ModelState.IsValid)
        {
            return View(model);
        }
        
        var result = await SignInManager.PasswordSignInAsync(username, model.Password, model.RememberMe, shouldLockout: false);
        
        switch (result)
        {
        case SignInStatus.Success:
            if(returnUrl != "Account/Register")
            {
                return RedirectToLocal(returnUrl);
            }   
             else
            {
                return RedirectToAction("Index", "Home");
            }
        case SignInStatus.LockedOut:
            return View("Lockout");
        case SignInStatus.RequiresVerification:
            return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
        case SignInStatus.Failure:
        default:
            ModelState.AddModelError("", "Invalid login attempt.");
            return View(model);
    }
    }
