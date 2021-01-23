    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Login(CredentialsViewModel model)
    {
        if (!ModelState.IsValid) return View("Login");
        var result = await ar.AuthenticateUser(model.UserName, model.Password);
        if (!result.IsCompleted)
        {
            ModelState.AddModelError("CustomError", "Вход в систему с указанными логином и паролем невозможен");
            return View("Login");
        }
        FormsAuthentication.SetAuthCookie(model.UserName, false);
        return RedirectToAction("Index", "Home");
    }
