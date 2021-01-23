    UserManager<User> userManager = new UserManager<User>(new UserStore());
    if (userManager.SupportsUserLockout && userManager.IsLockedOut(userId))
        return;
    var user = userManager.FindById(userId);
    if (userManager.CheckPassword(user, password))
    {
        if (userManager.SupportsUserLockout && userManager.GetAccessFailedCount(userId) > 0)
        {
            userManager.ResetAccessFailedCount(userId);
        }
        // Authenticate user
    }
    else
    {
        if (userManager.SupportsUserLockout && userManager.GetLockoutEnabled(userId))
        {
            userManager.AccessFailed(userId);
        }
    }
