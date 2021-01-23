    var userManager = HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>();
    const string name = "YourUsername"
    const string roleName = "Admin";
        
    var user = userManager.FindByName(name);
    //check for user roles
    var rolesForUser = userManager.GetRoles(user.Id);
    //if user is not in role, add him to it
    if (!rolesForUser.Contains(role.Name)) 
    {
        userManager.AddToRole(user.Id, role.Name);
    }
