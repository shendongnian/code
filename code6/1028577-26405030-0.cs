    public class PortfolioDBContext : DbContext
    {
    	public PortfolioDBContext() : base("PortfolioDBContext") { }
    	
    	public DbSet<Product> Portfolio { get; set; }
    }
