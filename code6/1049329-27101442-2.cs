    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Sprint>()
            .HasKey(s => s.ID)
            .HasRequired(s => s.Project)
            .WithMany(p => p.Sprints)
            .HasForeignKey(s => s.ProjectId);
        modelBuilder.Entity<Project>()
            .HasKey(p => p.ID)
            .HasOptional(p => p.Backlog); // changed
    }
