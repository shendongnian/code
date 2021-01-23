    if (ModelState.IsValid && WebSecurity.Login(model.UserName, model.Password, 
                                               persistCookie: model.RememberMe))
    {
        try
        {
             try
             {
                 //below is my custom method IsValidUser with my own logic for 
                 // valid user
                 MembershipCore.IsValidUser(model.UserName);
                 if (MembershipCore.isFirstTimeLogin(model.UserName))
                 {
                        //Show License Screen in a window
                        return RedirectToAction("License");
    
                  }
                  //my custom method setting custom Session variables
                  MembershipCore.SetLoggedInUser(model.UserName);
              }
          }
    }
