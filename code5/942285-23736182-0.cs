            if (context.Users.Any(u => u.UserName == User.Identity.Name))
            {
                var store = new Microsoft.AspNet.Identity.EntityFramework.UserStore<ApplicationUser>(context);
                var manager = new Microsoft.AspNet.Identity.UserManager<ApplicationUser>(store);
                ApplicationUser user = manager.FindByName<ApplicationUser>(User.Identity.Name);
                if (manager.IsInRole(user.Id, "Moderator") == true)
                {
                    // Do whatever you want...
                }
            }
