    public class MyDbContext : DbContext
    {
        public IDbSet<ArrayValue> ArrayValues { get; set; }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
             // there are several options here...
        }
    }
