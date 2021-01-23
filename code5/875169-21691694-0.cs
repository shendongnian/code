        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Student>()
                .HasMany(t => t.EnrolledCourses)
                .WithMany(t => t.EnrolledStudents);
        }
    
