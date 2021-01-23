        class ProjectConfiguration : EntityTypeConfiguration<Project>
        {
            public ProjectConfiguration()
            {
                HasRequired(e => e.CreatedBy).WithMany(); // one-to-many
                HasMany(e => e.Members).WithMany(); //many-to-many
            }
        }
        
        public class Context : DbContext
        {
            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder.Configurations.Add(new ProjectConfiguration());
            }
        }
