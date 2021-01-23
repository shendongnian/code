    public class TenantRepository : RepositoryBase<TenantModel>, ITenantRepository
    {
        public TenantRepository(UserModel loggedOnUser, IDbProvider dbProvider) : base(loggedOnUser, dbProvider)
        {
        }
    }
