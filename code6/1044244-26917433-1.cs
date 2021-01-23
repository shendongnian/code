    public class MyDBContext: DbContext 
    {
        public MyDBContext() : base("myConnString")
        {            
            //Disable initializer
            Database.SetInitializer<MyDBContext>(null);
        }
        public DbSet<A> As { get; set; }
        public DbSet<B> Bs { get; set; }
    }
