    public class MyDbContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
             modelBuilder.Entity<MyModel>()
                .Ignore(m => m.PlainTextInfo);
        }
    }
