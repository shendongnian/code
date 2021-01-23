    try
    {
        var user = db.Users.Where(u => u.Email.Equals(model.Email)).Single(); // where db is ApplicationDbContext instance
        var result = await SignInManager.PasswordSignInAsync(user.UserName, model.Password, model.RememberMe, shouldLockout: false);
    }
    catch (InvalidOperationException)
    {
        // the user is not exist
    }
