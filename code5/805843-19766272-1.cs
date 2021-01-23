    public class MyClaimsIdentityFactory<IUser> : ClaimsIdentityFactory<IUser> where IUser : IdentityUser
    {
        public MyClaimsIdentityFactory(): base()
        {
    
        }
        public override System.Threading.Tasks.Task<System.Security.Claims.ClaimsIdentity> CreateAsync(UserManager<IUser> manager, IUser user, string authenticationType)
        {
            // Override Creation of ClaimsIdentity and return it.
        }
    }
