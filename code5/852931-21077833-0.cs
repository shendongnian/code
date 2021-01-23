        protected async Task<bool> AddRoleAndUser(ZTTDD.Models.ApplicationDbContext context, NewUser newUser)
        {
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            IdentityResult result = IdentityResult.Success; 
            var user = UserManager.FindByName(newUser.UserName);
            if (user != null)
            {
                user = new ApplicationUser() { UserName = newUser.UserName, Email = newUser.Email };
                result = await UserManager.CreateAsync(user, newUser.Password);
                if (!result.Succeeded)
                    Console.Write("Unable to create user: " + newUser.UserName);
                    return false;
            }
            foreach (string r in newUser.Roles)
            {
                if (!RoleManager.RoleExists(r))
                {
                    var role = new IdentityRole(r);
                    result = await RoleManager.CreateAsync(role);
                    if (!result.Succeeded)
                        Console.Write("Unable to create role: " + r);
                        return false;
                }
                result = await UserManager.AddToRoleAsync(user.Id, r);
                if (!result.Succeeded)
                {
                    Console.Write("Unable to add user '" + newUser.UserName + "' to role '" + r + "'.");
                }
            }
            return result.Succeeded;
        }
