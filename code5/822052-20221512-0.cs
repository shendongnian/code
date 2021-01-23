        modelBuilder.Entity<Student>().HasRequired(s => s.Department);
        modelBuilder.Entity<Course>().HasRequired(u => u.Department);
        modelBuilder.Entity<Course>()
                    .HasMany(u => u.Students)
                    .WithMany(s => s.Courses);
                    .WillCascadeOnDelete(false);
        modelBuilder.Entity<Site>()
                    .HasMany(s => s.Courses)
                    .WithOptional()
                    .WillCascadeOnDelete(false);
