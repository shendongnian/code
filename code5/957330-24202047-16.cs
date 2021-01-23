    public class DbContextB: CommonDbContext
    {
        public DbContextB() :base("SimilarB") { } // Connection for B
        public IDbSet<Table2B> Tables2B { get; set; }
    }
