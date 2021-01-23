    public class MyDbContext : DbContext
    {
        public DbSet<FormBase> Forms { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CheckRequestModel>().Map(r => {
                r.ToTable("CheckRequests");
            });
        }
    }
