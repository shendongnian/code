     public class SchoolPlusDBContext : DbContext
    {
        public SchoolPlusDBContext()
            : base("name=SchoolPlusDBContext")
        {
        }
       
        
        public DbSet<CategoryMaster> CategoryMaster { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        } 
    }
