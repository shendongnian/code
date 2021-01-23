    public class CustomPrincipal:IPrincipal
        {
            public IIdentity Identity { get; set; }
            public bool IsInRole(string role) { return false; }
            public CustomPrincipal(string username)
            {
                this.Identity = new GenericIdentity(username);
            }
        }
