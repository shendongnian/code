    var validPass= await userManager.PasswordValidator.ValidateAsync(txtPassword1.Text);
    if(validPass.Succeeded)
    {
        var user = userManager.FindByName(currentUser.LoginName);
        user.PasswordHash = userManager.PasswordHasher.HashPassword(txtPassword1.Text);
        var res= userManager.Update(user);
        if(res.Succeeded)
        {
            // change password has been succeeded
        }
    }
