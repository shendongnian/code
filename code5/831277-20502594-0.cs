    public class DomanUserLoginProvider : ILoginProvider
    {
        public bool ValidateCredentials(string userName, string password, out ClaimsIdentity identity)
        {
            using (var pc = new PrincipalContext(ContextType.Domain, _domain))
            {
                bool isValid = pc.ValidateCredentials(userName, password);
                if (isValid)
                {
                    identity = new ClaimsIdentity(Startup.OAuthOptions.AuthenticationType);
                    identity.AddClaim(new Claim(ClaimTypes.Name, userName));
                }
                else
                {
                    identity = null;
                }
                return isValid;
            }
        }
        public DomanUserLoginProvider(string domain)
        {
            _domain = domain;
        }
        private readonly string _domain;
    }
