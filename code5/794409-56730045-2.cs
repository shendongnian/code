    protected override void OnModelCreating(ModelBuilder builder)
	{
		base.OnModelCreating(builder);
		builder.Entity<IdentityRole>().ToTable("Role");
		builder.Entity<IdentityUser>(entity => 
		{
			entity.ToTable("User");
			entity.Property(p => p.Id).HasColumnName("UserId");
		});
	}
