    public class AuthorizeRolesAttribute : AuthorizeAttribute
    {
        private new List<string> Roles;
        public AuthorizeRolesAttribute(params string[] roles) : base()
        {
            Roles = roles.toList()
        }
    }
