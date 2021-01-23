    public static void RegisterUserRoles()
    {
         ApplicationDbContext context = new ApplicationDbContext();
    
         var RoleManager = new RoleManager<Role, long>(new RoleStore(context));
    
         if (!RoleManager.RoleExists("Administrador"))
         {
             var adminRole = new Role {
                  Name = "Administrador",
             };
             RoleManager.Create(adminRole);
         }
    }
