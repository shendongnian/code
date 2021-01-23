        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (model.Username == "User" && model.Password == "Pa$$W0rd")
                {
                    FormsAuthentication.SetAuthCookie(model.Username, model.RememberMe);
                    if (!string.IsNullOrWhiteSpace(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    return RedirectToAction("Index", "Admin", new { area = "Admin"});
                }
                ModelState.AddModelError("", "Brukernavn og/eller passord er feil");
            }
            return View();
        }
