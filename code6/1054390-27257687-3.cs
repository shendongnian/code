    public class MyDbContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Application>().HasRequitred(x => x.User)
                                              .WithMany()
                                              .HasForeignKey(k => k.ApplicationUserId);
        }
    }
