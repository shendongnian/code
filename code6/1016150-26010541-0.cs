        var userName = model.UserName;
        using (var context = new ApplicationDbContext())
        {
           var user = context.Users.FirstOrDefault(p => p.Email == model.UserName);
           if (user != null)
           {
               userName = user.UserName;
           }
        }
    
    var result = await SignInManager.PasswordSignInAsync(userName, model.Password, model.RememberMe, shouldLockout: true);
