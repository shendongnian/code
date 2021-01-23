        var userStore = new UserStore<IdentityUser>();
        var userManager = new UserManager<IdentityUser>(userStore);
        string userId = UserName.Text;
        var user =userManager.FindByName(userId);
        if (user.PasswordHash != null  )
        {
            userManager.RemovePassword(user.Id);
        }
        userManager.AddPassword(user.Id, newpassword);
