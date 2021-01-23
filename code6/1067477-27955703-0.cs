        interface IDomainPrincipal : IPrincipal
        {
            int Id { get; set; }
            string UserName { get; set; }
            string AvatarUrl { get; set; }
        }
    
        public class DomainPrincipal : IDomainPrincipal
        {
            public IIdentity Identity { get; private set; }
            public bool IsInRole(string role) { return false; }
    
            public DomainPrincipal(string email)
            {
                this.Identity = new GenericIdentity(email);
            }
    
            public int Id { get; set; }
            public string UserName { get; set; }
            public string AvatarUrl { get; set; }
        }
       
