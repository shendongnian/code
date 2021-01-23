    public class AspNetUser : IdentityUser { /*customization*/ }
    public class AspNetRole : IdentityRole { /*customization*/ }
        
    public class PayrollDBEntities : IdentityDbContext //or : IdentityDbContext <AspNetUser, AspNetRole, string, IdentityUserLogin, IdentityUserRole, IdentityUserClaim> 
    {
    }
    public class Factory 
    {
        public IdentityDbContext DbContext 
        { 
            get 
            {
                return new PayrollDBEntities();
            } 
        }
        public UserStore<AspNetUser, AspNetRole, string, IdentityUserLogin, IdentityUserRole, IdentityUserClaim> UserStore
        {
            get 
            {                
                return new UserStore<AspNetUser, AspNetRole, string, IdentityUserLogin, IdentityUserRole, IdentityUserClaim>(DbContext);
            }
        }
        public UserManager<AspNetUser, string> UserManager
        { 
            get 
            {
                return new UserManager<AspNetUser, string>(UserStore);
            } 
        }
        public RoleStore<AspNetRole> RoleStore 
        {
            get 
            {
                return new RoleStore<AspNetRole>(DbContext);
            }
        }
        public RoleManager<AspNetRole> RoleManager 
        {
            get 
            {
                return new RoleManager<AspNetRole>(RoleStore);
            }
        }
    }
