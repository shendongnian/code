    public class MyContext : DbContext
    {
        public DbSet<Contact> Contacts { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var contactConfiguration = new EntityTypeConfiguration<Contact>();
            contactConfiguration.HasOptional(c => c.Secretary).WithOptionalPrincipal();
            contactConfiguration.HasOptional(c => c.Assistant).WithOptionalPrincipal();
            modelBuilder.Configurations.Add(contactConfiguration);
        }
    }
