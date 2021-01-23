    public ActionResult Register(RegisterModel model)
            {
                if (ModelState.IsValid)
                {
                    // Attempt to register the user
    
                    try
                    {
                       WebSecurity.CreateUserAndAccount(model.UserName, model.Password, new { UserType = model.UserType });
    
                       return RedirectToAction("Index", "Home");
    
                    }
                    catch (MembershipCreateUserException e)
                    {
                        ModelState.AddModelError("", ErrorCodeToString(e.StatusCode));
                    }
                }
