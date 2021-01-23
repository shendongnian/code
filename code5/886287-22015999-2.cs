    public virtual async Task<IdentityResult> RemovePasswordAsync(string userId)
    {
        var user = await _store.FindByIdAsync(userId);
        if (user == null)
            throw new InstanceNotFoundException("user");
        user.PasswordHash = String.Empty;
        user.SecurityStamp = String.Empty;
        return await UpdateAsync(user);
    }
	
