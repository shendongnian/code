        var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
        var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
        var user = new ApplicationUser() { UserName = Email.Text, Email = Email.Text };
        IdentityResult result = manager.Create(user, Password.Text);
        if (result.Succeeded)
        {
        }
