        var roleManager = HttpContext.GetOwinContext().Get<ApplicationRoleManager>();
    
        const string roleName = "Admin";
    
        //Create Role Admin if it does not exist
        var role = roleManager.FindByName(roleName);
        if (role == null)
        {
            role = new CustomRole();
            role.Id = 1; // this will be integer
            role.Name = roleName;
    
            var roleresult = roleManager.Create(role);
        }
