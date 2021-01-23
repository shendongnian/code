    [HttpPost, AllowAnonymous, ValidateAntiForgeryToken]
    public ActionResult ForgotPassword(ForgotPasswordModel model)
    {
        if (ModelState.IsValid)
        {
           try
           {
               //Reset password using the reset token and the new password
               WebSecurity.ResetPassword(model.ResetToken, model.TheUsersNewPassword);
               //Redirect to the home account page.
               return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
               ModelState.AddModelError(string.Empty, LocalizedText.Account_Reset_Password_Error);
            }
        }
       //Something bad happen, notify the user
       return View(model);
    }
