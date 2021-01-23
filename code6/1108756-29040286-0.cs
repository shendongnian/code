    var user = await UserManager.FindByEmailAsync(model.Email);
    if (user != null)
    {
        if(await UserManager.IsInRoleAsync(user.Id, "YourApprovedRole"))
        {
            // Sign in
        }
        else
        {
            // Error
        }
    }
