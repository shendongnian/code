    public class EntityFrameworkRepository<T> : Repository<T>
        where T : PersistentObject
    {
        private readonly DbSet<T> set;
        private readonly IApplicationContext applicationContext;
        private readonly IQueryable<T> queryable;
        public EntityFrameworkRepository(DbSet<T> set,
                                     IApplicationContext applicationContext)
        {
            this.set = set;
            this.applicationContext = applicationContext;
        }
    }
    public class CompanyRepository<T> : Repository<T>
        where T : PersistentObject, ICompany
    {
        public CompanyRepository(DbSet<T> set,
                                     IApplicationContext applicationContext)
        {
            this.set = setFilteredById(set, applicationContext.CompanyId);    
        }
    }
