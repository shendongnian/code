    string [] roleNames = { "role1", "role2", "role3" };
    var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
                    
                    IdentityResult roleResult;
                    foreach(var roleName in roleNames)
                    {
                        if(!RoleManager.RoleExists(roleName))
                        {
                            roleResult = RoleManager.Create(new IdentityRole(roleName));
                        }
                    }
                    var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                    UserManager.AddToRole("user", "role1");
                    UserManager.AddToRole("user", "role2");
                    context.SaveChanges();
    
