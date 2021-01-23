    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Login(LoginModel model, string returnUrl)
    {
        ParseUser user;
        try
        {
            user = await ParseUser.LogInAsync(model.UserName, model.Password);
        }
        catch (Exception e)
        {
            ModelState.AddModelError("", "The user name or password provided is incorrect.");
            return View(model);
        }
        FormsAuthentication.SetAuthCookie(user.Username, false);
        ParseUser.LogOut();
        return RedirectToLocal(returnUrl);
    }
