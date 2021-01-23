    [HttpPost]
    public ActionResult Login(User model, string returnUrl)
    {
        // Lets first check if the Model is valid or not
        if (ModelState.IsValid)
        {
            using (MyMainDBEntities entities = new MyMainDBEntities())
            {
                string username = model.username;
                string password = model.password;
                bool userValid = entities.Users.Any(user => user.username == username && user.password == password);
    
                // User found in the database
                if (userValid)
                {
                    FormsAuthentication.SetAuthCookie(username, false);
                    if (Url.IsLocalUrl(returnUrl) && returnUrl.Length > 1 && returnUrl.StartsWith("/")
                        && !returnUrl.StartsWith("//") && !returnUrl.StartsWith("/\\"))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "The user name or password provided is incorrect.");
                }
            }
        }
    
        // If we got this far, something failed, redisplay form
        return View(model);
    }
