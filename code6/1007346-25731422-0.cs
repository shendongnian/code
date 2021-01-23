    using System.Security.Claims;
    using System.Threading.Tasks;
    using Domain.Models;
    using Microsoft.AspNet.Identity;
    public class AppClaimsIdentityFactory : IClaimsIdentityFactory<User, int>
    {
        internal const string IdentityProviderClaimType = "http://schemas.microsoft.com/accesscontrolservice/2010/07/claims/identityprovider";
        internal const string DefaultIdentityProviderClaimValue = "My Identity Provider";
        /// <summary>
        ///     Constructor
        /// </summary>
        public AppClaimsIdentityFactory()
        {
            RoleClaimType = ClaimsIdentity.DefaultRoleClaimType;
            UserIdClaimType = ClaimTypes.NameIdentifier;
            UserNameClaimType = ClaimsIdentity.DefaultNameClaimType;
            SecurityStampClaimType = Constants.DefaultSecurityStampClaimType;
        }
        /// <summary>
        ///     Claim type used for role claims
        /// </summary>
        public string RoleClaimType { get; set; }
        /// <summary>
        ///     Claim type used for the user name
        /// </summary>
        public string UserNameClaimType { get; set; }
        /// <summary>
        ///     Claim type used for the user id
        /// </summary>
        public string UserIdClaimType { get; set; }
        /// <summary>
        ///     Claim type used for the user security stamp
        /// </summary>
        public string SecurityStampClaimType { get; set; }
        /// <summary>
        ///     Create a ClaimsIdentity from a user
        /// </summary>
        /// <param name="manager"></param>
        /// <param name="user"></param>
        /// <param name="authenticationType"></param>
        /// <returns></returns>
        public virtual async Task<ClaimsIdentity> CreateAsync(UserManager<User, int> manager, User user, string authenticationType)
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
            id.AddClaim(new Claim(UserIdClaimType, user.Id.ToString(), ClaimValueTypes.String));
            id.AddClaim(new Claim(UserNameClaimType, user.UserName, ClaimValueTypes.String));
            id.AddClaim(new Claim(IdentityProviderClaimType, DefaultIdentityProviderClaimValue, ClaimValueTypes.String));
            id.AddClaim(new Claim(ClaimTypes.Email, user.EmailAddress));
            if (user.ContactInfo.FirstName != null && user.ContactInfo.LastName != null)
            {
                id.AddClaim(new Claim(ClaimTypes.GivenName, user.ContactInfo.FirstName));
                id.AddClaim(new Claim(ClaimTypes.Surname, user.ContactInfo.LastName));
            }
            if (manager.SupportsUserSecurityStamp)
            {
                id.AddClaim(new Claim(SecurityStampClaimType,
                    await manager.GetSecurityStampAsync(user.Id)));
            }
            if (manager.SupportsUserRole)
            {
                user.Roles.ToList().ForEach(r =>
                    id.AddClaim(new Claim(ClaimTypes.Role, r.Id.ToString(), ClaimValueTypes.String)));
            }
            if (manager.SupportsUserClaim)
            {
                id.AddClaims(await manager.GetClaimsAsync(user.Id));
            }
            return id;
        }
