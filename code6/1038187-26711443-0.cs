    public class YourDbContext : DbContext
    {
         ... your DbSet properties
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tree>()
                    .HasMany<TreeComment>(o => o.Comments)
                    .WithRequired(com => com.Tree)
                    .HasForeignKey(com => ds.TreeID)
                    .WillCascadeOnDelete(false);
         }
    }
