    private void AddErrors(IdentityResult result)
    {
        foreach (var error in result.Errors)
        {
            if (error.EndsWith("is already taken."))
                ModelState.AddModelError("", "User with the given email address already exists");
            else ModelState.AddModelError("", error);
        }
    }
