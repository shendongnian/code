    var roleManager = new RoleManager<Microsoft.AspNet.Identity.EntityFramework.IdentityRole>(new RoleStore<IdentityRole>(new ApplicationDbContext()));
        
        
       if(!roleManager.RoleExists("ROLE NAME"))
       {
          var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
          role.Name = "ROLE NAME";
          roleManager.Create(role);
    
        }
