    public class PortfolioDBContext : DbContext
    {
        public PortfolioDBContext()
        {
            Database.Log = s => Debug.WriteLine(s);
        }
        public DbSet<Product> Portfolio { get; set; }
    }
