    public class SecurityUnitOfWork : ISecurityUnitOfWork 
    {
        private readonly ISecurityContext securityContext;
        public SecurityUnitOfWork(ISecurityContext securityContext)
        {
            this.securityContext = securityContext;
        }
    }
