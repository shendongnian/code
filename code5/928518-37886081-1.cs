    internal class Security
    {
    ApplicationDbContext context = new ApplicationDbContext();
    internal void AddUserToRole(string userName, string roleName)
    {
        var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
        try
        {
            var user = UserManager.FindByName(userName);
            UserManager.AddToRole(user.Id, roleName);
            context.SaveChanges();
        }
        catch
        {
            throw;
        }
    }
    }
