    public class DbContextA : CommonDbContext
    {
        public DbContextA() : base("SimilarA") { } // connection for A
        public IDbSet<Table2A> Tables2A { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Ignore<Table2B>(); // Ignore Table B
        }
    }
