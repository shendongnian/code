    public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
    {
        ...
        var user = await UserManager.FindByNameAsync(model.Username);
        if (user != null && ValidateDomainCredentials(user.user_Name, model.Password))
        {
            await SignInAsync(user, model.RememberMe);
            return RedirectToLocal(returnUrl);
        }
    }
