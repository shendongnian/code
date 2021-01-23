        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index(User model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var result = 
                await signInManager.PasswordSignInViaEmailAsync(
                    model.Email,
                    model.Password, 
                    model.StaySignedIn,
                    true);
            var errorMessage = string.Empty;
            switch (result)
            {
                case SignInStatus.Success:
                    if (IsLocalValidUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    return RedirectToAction("Index", "Home");
                case SignInStatus.Failure:
                    errorMessage = Messages.LoginController_Index_AuthorizationError;
                    break;
                case SignInStatus.LockedOut:
                    errorMessage = Messages.LoginController_Index_LockoutError;
                    break;
                case SignInStatus.RequiresVerification:
                    throw new NotImplementedException();
            }
            ModelState.AddModelError(string.Empty, errorMessage);
            return View(model);
        }
