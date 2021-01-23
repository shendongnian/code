    [HttpPost]
    public ActionResult Login(LoginModel model, string returnUrl)
    {
        // Lets first check if the Model is valid or not
        if (ModelState.IsValid)
        {
                // User found in the database
                if (model.IsValid(model.Email, model.Password )) //According to the design you have in the link given above
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
    
        // If we got this far, something failed, redisplay form
        return View(model);
    }
