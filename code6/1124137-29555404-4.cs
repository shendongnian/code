    public partial class YourContext: DbContext
        {
            static YourContext() { }
    
            //Class constructor with Connection String name
            public YourContext() : base("name=YourConnectionString") { }
    
            public DbSet<Indicator> Indicators{ get; set; }
            public DbSet<InteractiveObject> InteractiveObjects { get; set; }
    }
