    modelBuilder.Entity<Entity>()
    	.ToTable("dbo.Entity")
    	.HasKey(s => s.Id);
    
    modelBuilder.Entity<Entity>()
    	.Property(s => s.Code)
    	.IsRequired();
    
    modelBuilder.Entity<Entity>()
    	.Ignore(s => s.MyCode);
