    public class SecurityUnitOfWork : UnitOfWork,ISecurityUnitOfWork 
    {
        public SecurityUnitOfWork(ISecurityContext context)
            : base(context)
        {
            // This change
        }    
