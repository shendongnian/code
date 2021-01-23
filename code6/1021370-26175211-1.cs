        var roleStore = new RoleStore<IdentityRole>(context);
        var roleManager = new RoleManager<IdentityRole>(roleStore);
        var applicationRoleAdministrator = new IdentityRole("Administrator");
        if (!roleManager.RoleExists(applicationRoleAdministrator.Name))
        {
           roleManager.Create(applicationRoleAdministrator);
        }
    // do some logic to find your applicationUserAdministrator
    var applicationUserAdministrator = userManager.FindByName("Administrator");
    userManager.AddToRole(applicationUserAdministrator.Id, applicationRoleAdministrator.Name);
