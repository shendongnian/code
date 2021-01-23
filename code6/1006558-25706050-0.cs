    // Get user
    var user = await UserManager.FindByIdAsync(id);
    
    //Get user roles
    var userRoles = await UserManager.GetRolesAsync(user.Id);
    
    //Get user role names 
    var userRoleNames = RoleManager.Roles.Where(x => userRoles.Contains(x.Name)).Select(x=>x.Name).ToList();
