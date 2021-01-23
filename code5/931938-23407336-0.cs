    using Microsoft.AspNet.Identity;
    var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>());
    var roles = new List<string> { "admin", "contributor" };
    var currentUser = manager.FindById(User.Identity.GetUserId());  
              
    if (currentUser.Roles.Any(u => roles.Contains(u.Role.Name)))
    {
                    
    }     
