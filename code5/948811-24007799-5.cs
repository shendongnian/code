    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {  
        modelBuilder.Entity<MenuItem>()
                .HasOptional(x => x.UseSiblingClaim)
                .WithMany()
                .HasForeignKey(x => x.UseSiblingClaim_Id);
        base.OnModelCreating(modelBuilder);
    }
