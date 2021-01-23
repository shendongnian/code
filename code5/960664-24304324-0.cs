    public async Task<IdentityResult> RegisterAsync(RegisterViewModel model)
    {
        var user = new UserEntity { UserName = model.UserName };
        var role = model.Role.ToString();
        if (await _roleManager.FindByNameAsync(role) == null)
        {
            var roleResult = await _roleManager.CreateAsync(new RoleEntity(role));
            if (roleResult != IdentityResult.Success)
            {
                return roleResult;
            }
        }
        var result = await _userManager.CreateAsync(user, model.Password);
        if (!result.Succeeded)
        {
            return result;
        }
        var addToRoleResult = await _userManager.AddToRoleAsync(user.Id, role);
        return !addToRoleResult.Succeeded ? addToRoleResult : IdentityResult.Success;
    }
