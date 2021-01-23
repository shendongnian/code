     public class MyContext : DbContext
     {        
        public MyContext()
        {
        }
        public DbSet<Entity1> Entities1{ get; set; }
        public DbSet<Entity2> Entities2 { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new Entity1Map());
            modelBuilder.Configurations.Add(new Entity2Map());
            base.OnModelCreating(modelBuilder);
        }
    }
