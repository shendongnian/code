    public class FirebirdEmbededExampleDbContext : DbContext
    {
        public FirebirdEmbededExampleDbContext(string connString) 
          : base(new FbConnection(connString), true)
        { }
    
        public DbSet<ItemA> ItemsA { get; set; }
        public DbSet<ItemB> ItemsB { get; set; }
    }
