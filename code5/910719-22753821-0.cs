    public class IdentityManager
    {
        private ApplicationDbContext context;
    
        public IdentityManager ()
        {
            context = new ApplicationDbContext(); // if none supplied
        }
    
        public IdentityManager (ApplicationDbContext applicationDbContext)
        {
            context = applicationDbContext;
        }
    
        public bool AddUserToRole(string userId, string roleName)
        {
            var um = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var idResult = um.AddToRole(userId, roleName);
            return idResult.Succeeded;
        }
    
        public void ClearUserRoles(string userId)
        {
            var um = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var user = um.FindById(userId);
            var currentRoles = new List<IdentityUserRole>();
            currentRoles.AddRange(user.Roles);
            foreach (var role in currentRoles)
            {
                um.RemoveFromRole(userId, role.RoleId);
            }
        }
    }
