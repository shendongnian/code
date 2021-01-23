    [HttpPost]
    [ValidateAntiForgeryToken]
    [AllowAnonymous]
    //[RecaptchaControlMvc.CaptchaValidator]
    public virtual async Task<ActionResult> ResetPassword(
                                                  ResetPasswordViewModel rpvm)
    {
        string message = null;
        //the token is valid for one day
        var until = DateTime.Now.AddDays(1);
        //We find the user, as the token can not generate the e-mail address, 
        //but the name should be.
        var db = new Context();
        var user = db.Users.SingleOrDefault(x=>x.Email == rpvm.Email);
    
        var token = new StringBuilder();
            
        //Prepare a 10-character random text
        using (RNGCryptoServiceProvider 
                            rngCsp = new RNGCryptoServiceProvider())
        {
            var data = new byte[4];
            for (int i = 0; i < 10; i++)
            {
                //filled with an array of random numbers
                rngCsp.GetBytes(data);
                //this is converted into a character from A to Z
                var randomchar = Convert.ToChar(
                                          //produce a random number 
                                          //between 0 and 25
                                          BitConverter.ToUInt32(data, 0) % 26 
                                          //Convert.ToInt32('A')==65
                                          + 65
                                 );
                token.Append(randomchar);
            }
        }
        //This will be the password change identifier 
        //that the user will be sent out
        var tokenid = token.ToString();
    
        if (null!=user)
        {
            //Generating a token
            var result = await IdentityManager
                                    .Passwords
                                    .GenerateResetPasswordTokenAsync(
                                                  tokenid, 
                                                  user.UserName, 
                                                  until
                               );
   
            if (result.Success)
            {
                //send the email
                ...
            }
        }
        message = 
            "We have sent a password reset request if the email is verified.";
        return RedirectToAction(
                       MVC.Account.ResetPasswordWithToken(
                                   token: string.Empty, 
                                   message: message
                       )
               );
    }
