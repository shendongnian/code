    public static bool IsInIdentityRole(this IPrincipal user, string role)
    {
        var userManager = GetUserManager(); //implement this!
        return userManager.IsInRole(user.Identity.GetUserId(), role); 
    }
