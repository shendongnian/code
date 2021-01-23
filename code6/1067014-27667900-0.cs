    public class RoleStore<TRole, TContext, TKey> : 
            IQueryableRoleStore<TRole>, 
            IRoleClaimStore<TRole>
            where TRole : IdentityRole<TKey>
            where TKey : IEquatable<TKey>
            where TContext : DbContext
    {
        public RoleStore(TContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }
            Context = context;
        }
    }
