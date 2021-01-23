    @{
        var context = new RaspberryPi.Models.ApplicationDbContext();          
        if (context.Users.Any(u => u.UserName == User.Identity.Name))
        {
            var store = new Microsoft.AspNet.Identity.EntityFramework.UserStore<applicationuser>();
            var manager = new Microsoft.AspNet.Identity.UserManager<applicationuser>(store);
            ApplicationUser user = manager.FindByName<applicationuser>(User.Identity.Name);
            if (manager.IsInRole(user.Id, "Moderator") == true)
            {
            // Do whatever you want...
            }
        }
