    public class MyContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Model1>()
                .HasRequired(e => e.Model2)
                .WithMany(e => e.Model1s)
                .HasForeignKey(e => new { e.fk_one, e.fk_two })
                .WillCascadeOnDelete(false);
        }
    }
