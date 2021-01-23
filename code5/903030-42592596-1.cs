        var userStore = new UserStore<IdentityUser>();
        var userManager = new UserManager<IdentityUser>(userStore);
        string userName= UserName.Text;
        var user =userManager.FindByName(userName);
        if (user.PasswordHash != null  )
        {
            userManager.RemovePassword(user.Id);
        }
        userManager.AddPassword(user.Id, newpassword);
