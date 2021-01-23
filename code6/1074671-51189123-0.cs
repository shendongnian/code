    string emailConfirmationCode = await 
    UserManager.GenerateEmailConfirmationTokenAsync(userID);
            string passwordSetCode = await UserManager.GeneratePasswordResetTokenAsync(userID);
    var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = userID, emailConfirmationCode = emailConfirmationCode, passwordSetCode = passwordSetCode }, protocol: Request.Url.Scheme);
    await UserManager.SendEmailAsync(userID, subject,$"Please confirm your account by clicking <a href=\"{callbackUrl}\">here</a>");
