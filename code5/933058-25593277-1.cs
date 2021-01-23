    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
	   base.OnModelCreating(modelBuilder);
	   modelBuilder.Entity<PermissionDependency>()
                   .HasRequired(d => d.Permission)
                   .WithMany(o => o.Dependencies);
    }
