    public class ClaimsTransformationModule : ClaimsAuthenticationManager
        {
            public override ClaimsPrincipal Authenticate(string resourceName, ClaimsPrincipal incomingPrincipal)
            {
                if (!incomingPrincipal.Identity.IsAuthenticated)
                {
                    return base.Authenticate(resourceName, incomingPrincipal);
                }
    
                return CreateApplicationPrincipal(incomingPrincipal.Identity.Name);
            }
    
            private ClaimsPrincipal CreateApplicationPrincipal(string userName)
            {
                var claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Name, userName));
                claims.Add(new Claim(ClaimTypes.GivenName, userName));
                // add roles
                var roles = Roles.GetRolesForUser(userName).ToList();
                roles.ForEach( 
                    r => claims.Add(new Claim(ClaimTypes.Role, r)));
    
                return new ClaimsPrincipal(new ClaimsIdentity(claims, "Custom"));
            }
    
        }
    public class CustomAuthorisationManager : ClaimsAuthorizationManager
    {
        public override bool CheckAccess(AuthorizationContext context)
        {
            string resource = context.Resource.First().Value;
            string action = context.Action.First().Value;
    
            if (action == "Edit" && resource == "User")
            {
                bool isAdmin = context.Principal.HasClaim(ClaimTypes.Role, "Admin");
                return isAdmin;
            }
    
            return false;
        }
    }
