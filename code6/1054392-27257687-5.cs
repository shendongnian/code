    public class MyDbContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Application>()
                        .HasRequired(x => x.User)
                        .WithMany()
                        .HasForeignKey(k => k.ApplicationUserId);
        }
    }
