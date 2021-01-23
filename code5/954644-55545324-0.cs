    public class UserManager : Microsoft.AspNet.Identity.UserManager<Employee, int>
    {
        public UserManager(IUserStore<Employee, int> store) : base(store)
        {
            ClaimsIdentityFactory = new ClaimsIdentityFactory();
        }
        
        ...
        
        public override async Task<ClaimsIdentity> CreateIdentityAsync(Employee user, string authenticationType)
        {
            if (user != null && /* user is active, etc */)
            {
                var userIdentity = await ClaimsIdentityFactory.CreateAsync(this, user, authenticationType);
                
                ...
                
                return userIdentity;
            }
            else
            {
                return null;
            }
        }
        
        ...
        
        public async Task<string> GetSecurityStampAsync(Employee user)
        {
            var securityStore = Store as IUserSecurityStampStore<Employee, int>;
            
            if (securityStore == null)
            {
                throw new NotSupportedException("User Store Not IUserSecurityStampStore");
            }
            
            return await securityStore.GetSecurityStampAsync(user).WithCurrentCulture();
        }
        
        public async Task<IList<string>> GetRolesAsync(Employee user)
        {
            var userRoleStore = Store as IUserRoleStore<Employee, int>;
            
            if (userRoleStore == null)
            {
                throw new NotSupportedException("User Store Not IUserRoleStore");
            }
            
            return await userRoleStore.GetRolesAsync(user).WithCurrentCulture();
        }
        
        public virtual async Task<IList<Claim>> GetClaimsAsync(Employee user)
        {
            var claimStore = Store as IUserClaimStore<Employee, int>;
            
            if (claimStore == null)
            {
                throw new NotSupportedException("User Store Not IUserClaimStore");
            }
            
            return await claimStore.GetClaimsAsync(user).WithCurrentCulture();
        }
    }
    public class ClaimsIdentityFactory : Microsoft.AspNet.Identity.ClaimsIdentityFactory<Employee, int>
    {
        ...
        public override async Task<ClaimsIdentity> CreateAsync(Microsoft.AspNet.Identity.UserManager<Employee, int> manager, Employee user, string authenticationType)
        {
            if (manager == null)
            {
                throw new ArgumentNullException("manager");
            }
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }
            var id = new ClaimsIdentity(authenticationType, UserNameClaimType, RoleClaimType);
            id.AddClaim(new Claim(UserIdClaimType, ConvertIdToString(user.Id), ClaimValueTypes.String));
            id.AddClaim(new Claim(UserNameClaimType, user.UserName, ClaimValueTypes.String));
            id.AddClaim(new Claim(IdentityProviderClaimType, DefaultIdentityProviderClaimValue, ClaimValueTypes.String));
            if (manager.SupportsUserSecurityStamp)
            {
                id.AddClaim(new Claim(SecurityStampClaimType, await (manager as UserManager).GetSecurityStampAsync(user).WithCurrentCulture()));
            }
            if (manager.SupportsUserRole)
            {
                IList<string> roles = await (manager as UserManager).GetRolesAsync(user).WithCurrentCulture();
                foreach (string roleName in roles)
                {
                    id.AddClaim(new Claim(RoleClaimType, roleName, ClaimValueTypes.String));
                }
            }
            if (manager.SupportsUserClaim)
            {
                id.AddClaims(await (manager as UserManager).GetClaimsAsync(user).WithCurrentCulture());
            }
            return id;
        }
    }
