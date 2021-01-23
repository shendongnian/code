    var roles = (WebMatrix.WebData.SimpleRoleProvider)Roles.Provider;
    if (!roles.GetRolesForUser(model.UserName).Contains("Admin"))
    {
        roles.AddUsersToRoles(new[] { model.UserName }, new[] { "Admin" });
    }
