    [HttpPost]
    [AllowAnonymous]
    public async Task<ActionResult> SendInvite(
        string email, string product)
    {
        ApplicationUser user = null;
        if (ModelState.IsValid)
        {
            user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
            if (user.IsAdmin != null && (bool)user.IsAdmin)
            {
                string key = String.Empty;
                string subMsg = String.Empty;
                var accessDB = new AccessHashesDbContext();
                switch (product) { /* do stuff */ }
    
                // Send email.
                try
                {
                    await Helpers.SendEmailAsync(new List<string>() { email }, null, "my message string");
                    return Content(String.Format("Invitation successfully sent to \"{0}\"", email));
                }
                catch (Exception)
                {
                    return Content(String.Format(
                        "Invitation to \"{0}\" failed",
                        email));
                }
            }
        }
    // you could redirect to another action, or return some other message
        return Content("not valid etc etc");
    }
