    public class Test
    {
        public long Id { get; set; }
        public string Field { get; set; }
    }
    public class TestDbContext : DbContext
    {
        public DbSet<Test> TestSet { get; set; }
        public TestDbContext() {}
        /// For self-composed connection string.
        public TestDbContext(DbConnection conn) : base(conn, true) {}
    }
