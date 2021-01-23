    public class ClaimsAuthorizeAttribute : Thinktecture.IdentityModel.Authorization.Mvc.ClaimsAuthorizeAttribute
    {
        private readonly string _action;
        private readonly string[] _resources;
        public ClaimsAuthorizeAttribute(string action, params string[] resources)
            :base(action, resources)
        {
            _action = action;
            _resources = resources;
        }
        public IEnumerable<Claim> GetClaims()
        {
            return _resources.Select(r => new Claim(_action, r));
        }
    }
