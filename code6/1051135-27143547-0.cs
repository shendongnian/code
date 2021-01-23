    [HttpPost]
    [AllowAnonymous]
    public void Login(LoginModel model, string returnUrl)
    {
    
        if (User.Identity.IsAuthenticated) 
               return RedirectToAction(...);
    
        if (ModelState.IsValid && WebSecurity.Login(model.EMail, model.Password, persistCookie: model.RememberMe))
        {
            return;
        }
    
        ModelState.AddModelError("", "The user name or password provided is incorrect.");
        return;
    }
