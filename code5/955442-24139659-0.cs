    class CustomPrincipal : IPrincipal
    {
        public IEnumerable<string> Roles { get; set; }
    
        public IIdentity Identity { get; set; }
    
        public bool IsInRole(string role)
            {
                // check user for appropriate roles
                return false;
            }
    }
    
    class CustomIdentity : IIdentity
    {
        public int UserId { get; set; }
    
        public string AuthenticationType { get; set; }
    
        public bool IsAuthenticated
        {
            get { return !string.IsNullOrWhiteSpace(Name); }
        }
    
        public string Name { get; set; }
    }
    
    class Program
    {
        static void Main(string[] args)
        {
            CustomIdentity identity = new CustomIdentity
            {
                UserId = 1,
                Name = "user1"
            };
    
            CustomPrincipal principal = new CustomPrincipal
            {
                Identity = identity,
                Roles = new List<string> { "admin", "superAdmin" }
            };
    
            System.Threading.Thread.CurrentPrincipal = principal;
        }
    }
