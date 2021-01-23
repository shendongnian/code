    [AllowAnonymous]
    public async Task<ActionResult> ConfirmEmail(string userId, string emailConfirmationCode, string passwordSetCode = null )
    {
        if (userId == null || emailConfirmationCode == null)
        {
            return View("Error");
        }
        var result = await UserManager.ConfirmEmailAsync(userId, emailConfirmationCode);
        if (result.Succeeded && !string.IsNullOrEmpty(passwordSetCode))
        {
            return RedirectToAction("ResetPassword", "Account", new { userId = userId, code = passwordSetCode, firstPassword = true  });
        }
        return View(result.Succeeded ? "ConfirmEmail" : "Error");
    }
