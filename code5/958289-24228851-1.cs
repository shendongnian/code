    public partial class northwindEntities : DbContext
        {
            public northwindEntities()
                : base("northwindEntities")
            {
            }
    
            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                throw new UnintentionalCodeFirstException();
            }
