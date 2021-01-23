    public class MyRepository<T>
    {
        public MyRepository(DbContext dbContext, int companyID)
        {
            if (dbContext == null) 
                throw new ArgumentNullException("Null DbContext");
            DbContext = dbContext;
            DbSet = DbContext.Set<T>();
            CompanyID = companyID;
        }
 
        protected DbContext DbContext { get; set; }
        protected int CompanyID  {get; set; }
        
        protected DbSet<T> DbSet { get; set; }
 
        // Add filter here
        public virtual IQueryable<T> GetAll()
        {
            return DbSet.Where(x => x.CompanyID == _cID);
        }
    }
