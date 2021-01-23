    [HttpPost]
    [ValidateAntiForgeryToken]
    publicasync Task<ActionResult> ManagePassword(ManageUserViewModel model)
    {
        if (Request.Form["email"] != null)
        {
          var email = Request.Form["email"].ToString();
          var user = UserManager.FindByEmail(email);
          var token = await UserManager.GeneratePasswordResetTokenAsync(user.Id);
           //before send mail
          token = HttpUtility.UrlEncode(token);   
      //mail send
        }
    }
