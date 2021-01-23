    public class MyContext : DbContext
    {
        public virtual DbSet<RegistrationForm> RegistrationForms { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
    }
    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<RegistrationForm>()
            .HasMany(r => r.Categories)
            .WithMany(c => c.RegistrationForms)
            .Map(
                m =>
                {
                  m.MapLeftKey("RegistrationID");
                  m.MapRightKey("CategoryID");
                  m.ToTable("RegistrationCategory");
                }
            );
    }
