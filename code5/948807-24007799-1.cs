    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MenuItem>()
                    .HasOptional(x=>x.UseSiblingClaim)                
                    .WithOptionalDependent()
                    .Map(m => m.MapKey("UseSiblingClaim_Id"));
        base.OnModelCreating(modelBuilder);
    }
