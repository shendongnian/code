        public ActionResult Login(LogOnModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var authService = AppHostBase.Resolve<AuthService>();
                    authService.RequestContext = System.Web.HttpContext.Current.ToRequestContext();
                    var response = authService.Authenticate(new Auth
                    {
                        UserName = model.UserName,
                        Password = model.Password,
                        RememberMe = model.RememberMe
                    });
                    // add ASP.NET auth cookie
                    FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
                    return RedirectToLocal(returnUrl);
                }
                catch (HttpError)
                {
                }
            }
            // If we got this far, something failed, redisplay form
            ModelState.AddModelError("", "The user name or password provided is incorrect.");
            return View(model);
        }
