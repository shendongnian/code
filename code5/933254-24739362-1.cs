    public class YourContextName : ApplicationDbContext
    {
        public DbSet<ABizClass1> BizClass1 { get; set; }
        public DbSet<ABizClass2> BizClass2 { get; set; }
        // And so forth ...
    }
