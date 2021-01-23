    var managerRole = TMRoles.GetIdentityRole(TMRoles.Manager);
    var managers = managerRole.Users;
    
    public class TMRoles
    {
        private static RoleManager<IdentityRole> RoleManager = 
            new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new TMContext()));
        public static string Manager { get { return "Manager"; } }
        public static IdentityRole GetIdentityRole(string roleName)
        {
            return RoleManager.FindByName(roleName);
        }
    }
