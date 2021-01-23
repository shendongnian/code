        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid )
            {
                if (UserManager.IsLoggedIn(model.UserName))
                {
                    ModelState.AddModelError("", "A user with that user name is already logged in.");
                    return View(model);
                }
                if (WebSecurity.Login(model.UserName, model.Password, persistCookie: model.RememberMe))
                {
                    UserManager.SetToLoggedIn(model.UserName);
                    return RedirectToLocal(returnUrl);
                }
            }
            // If we got this far, something failed, redisplay form
            ModelState.AddModelError("", "The user name or password provided is incorrect.");
            return View(model);
        }
