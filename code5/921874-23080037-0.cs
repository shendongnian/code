        public class MyContext : DbContext
        {
            public DbSet<OfficeAssignment> OfficeAssignments { get; set; }
            protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                modelBuilder.Entity<OfficeAssignment>() 
                            .HasRequired(t => t.Instructor) 
                            .WithOptional(t => t.OfficeAssignment);
                
                base.OnModelCreating(modelBuilder);
            }
        }
