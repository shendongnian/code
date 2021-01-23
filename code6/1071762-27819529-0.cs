    if (.. Succeeded)
    {
        ..
        // if (!await UserManager.IsInRoleAsync(user.Id, "Member"))
        await UserManager.AddToRoleAsync(user.Id, "Member");
    
        return RedirectToAction("Index", "Home");
    }
