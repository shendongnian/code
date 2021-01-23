    [HttpPost]
    public ActionResult Login(User model, string returnUrl)
    {
            //Validation code
            if (userValid)
            {
                 FormsAuthentication.SetAuthCookie(username, false);
            }
    }
