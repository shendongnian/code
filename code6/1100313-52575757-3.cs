    [HttpPost]
    public JsonResult Login([ModelBinder(typeof(JsonBinder<LoginViewModel>))] LoginViewModel model)
    {
        if (ModelState.IsValid)
        {
            //var result = await SignInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, shouldLockout: false);
            //if (result.Succeeded)
            //{
            //     //return RedirectToLocal(returnUrl);
            //}
            ModelState.AddModelError("", "Identifiant ou mot de passe invalide");
            return Json("error-model-wrong");
        }
        // If we got this far, something failed, redisplay form
        return Json("error-mode-not-valid");
    }
