     public partial class MyContextEntities : DbContext
        {
            public MyContextEntities(string ConnectionString="[Your Entity Connection String Here]")
                : base(ConnectionString)
            {
            }
        
            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                throw new UnintentionalCodeFirstException();
            }
    }
