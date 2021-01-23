    public partial class SomeContext : DbContext
    {
        static SomeContext()
        {
            Database.SetInitializer<SomeContext>(null);
        }
    
        public SomeContext()
            : base("Name=SomeContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new ReportMap());
        }
    }
