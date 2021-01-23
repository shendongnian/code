    var user = db.Users.Find(userId);
    foreach (string roleName in newRoles) {
        string roleId = RoleManager.FindByName(roleName).Id;
        var appUserRole = new ApplicationUserRole {
             UserId = user.Id,
             RoleId = roleId,
             CustomField1 = "value1",
             CustomField2 = "value2",
             ....
        };
        user.Roles.Add(appUserRole);
    }
