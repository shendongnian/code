    public async Task<IList<string>> UserRoles(string userId)
    {
        IList<string> roles = await userManager.GetRolesAsync(userId);
    
        return roles;
    }
