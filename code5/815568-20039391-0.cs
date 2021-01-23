        public class YourContext: DbContext
        {
    
        public YourContext() : base("name=YourContext")
        {
        }
        // Add a DbSet for each one of your Entities
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Meal> Meals { get; set; }
    
        }
