    modelBuilder.Entity<Department>()
        .HasMany( d => d.Students )
        .WithRequired()
        .WillCascadeOnDelete( false );
    modelBuilder.Entity<Department>()
        .HasMany( d => d.Courses )
        .WithRequired()
        .WillCascadeOnDelete( false );
    modelBuilder.Entity<Course>()
        .HasMany(u => u.Students)
        .WithMany(s => s.Courses);
