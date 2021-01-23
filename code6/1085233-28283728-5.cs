    var existingUserRoles = user.Roles.Select(m => m.RoleId);
    model.SelectedRoleIds.Except(existingUserRoles)
        .ToList().ForEach(roleId => user.Roles.Add(new IdentityUserRole
        {
            RoleId = roleId
        }));
