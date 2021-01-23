    [HttpPost]
    [AllowAnonymous]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Register(RegisterModel model)
    {
        if (ModelState.IsValid)
        {
            // Attempt to register the user
            try
            {
                var user = new ParseUser
                {
                    Username = model.UserName,
                    Password = model.Password,
                };
                await user.SignUpAsync();
                FormsAuthentication.SetAuthCookie(model.UserName, false);
                ParseUser.LogOut();
                return RedirectToAction("Index", "Home");
            }
            catch (ParseException e)
            {
                ModelState.AddModelError("", e.Message);
            }
        }
        // If we got this far, something failed, redisplay form
        return View(model);
    }
