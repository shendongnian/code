    using System.Data.Entity;
    
    namespace FlextrafikWeb.Models
    {
        public class Context : DbContext
        {
            public Context() : base("FlextrafikWeb")
    		{
    			Database.SetInitializer(new DatabaseInitializer());
    		}
    
            public DbSet<Car> Cars { get; set; }
            public DbSet<User> Users { get; set; }
            public DbSet<Location> Locations { get; set; }
            public DbSet<Price> Prices { get; set; }
        }
    }
