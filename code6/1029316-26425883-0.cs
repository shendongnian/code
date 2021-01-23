    public class StoreItemsContext : DbContext
    {
        public StoreItemsContext()
            : base("YourConnectionStringName")
        {
            Database.SetInitializer<StoreItemsContext>(null);
        }
        // DbSet's here
        publlic DbSet<Price> Prices { get; set; }
    }
