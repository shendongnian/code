        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindByNameAsync(model.Email);
                if (user == null)
                {
                    ModelState.AddModelError("", "Invalid login attempt.");
                    return View(model);
                }
                //Add this to check if the email was confirmed.
                if (!UserManager.IsEmailConfirmed(user.Id))
                {
                    ModelState.AddModelError("", "You need to confirm your email.");
                    return View(model);
                }
                if (await UserManager.IsLockedOutAsync(user.Id))
                {
                    return View("Lockout");
                }
                if (await UserManager.CheckPasswordAsync(user, model.Password))
                {
                    // Uncomment to enable lockout when password login fails
                    //await UserManager.ResetAccessFailedCountAsync(user.Id);
                    return await LoginCommon(user, model.RememberMe, returnUrl);
                }
                else
                {
                    // Uncomment to enable lockout when password login fails
                    //await UserManager.AccessFailedAsync(user.Id);
                    ModelState.AddModelError("", "Invalid login attempt.");
                    return View(model);
                }
            }
            // If we got this far, something failed, redisplay form
            return View(model);
        }
