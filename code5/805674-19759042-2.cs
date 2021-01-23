    public class RealContext
    {
         public DbSet<User> Users { get; set; }
         [...]
    }
    public class TenantContext 
    {
        private RealContext realContext;
        private int tenantId;
        public TenantContext(int tenantId)
        {
            realContext = new RealContext();
            this.tenantId= tenantId;
        }
        public IQueryable<User> Users { get { FilterTenant(realContext.Users); }     }
        private IQueryable<T> FilterTenant<T>(IQueryable<T> values) where T : class, ITenantData
        {
             return values.Where(x => x.TenantId == tenantId);
        }
        public int SaveChanges()
        {
            ApplyTenantIds();
            return realContext.SaveChanges();
        }
    }
