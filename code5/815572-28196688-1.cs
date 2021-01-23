      public class BlaBlaDB : DbContext
        {
            public DbSet<Models.MyOtherModel> MyOtherModels { get; set; }
    
            protected override void OnConfiguring(DbContextOptions options)
            {
                options.UseSqlServer();
            }
        }
