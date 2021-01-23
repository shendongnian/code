    public public class MyContext: Database02
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Client01>().ToTable("Client02");
        }
        // This static method was missing, it is required to disable the db initializer
        static MyContext()
        {
            Database.SetInitializer<MyContext>(null);
        }
    
