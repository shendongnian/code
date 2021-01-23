    public class MiniContext : DbContext
    {
        public MiniContext()
             : base("YourConnectionStringNameHere")
        {
            Database.SetInitializer<MiniContext>(null);
        }
    
        public DbSet<PurchaseItem> PurchaseItems { get; set; }
    }
