    protected override void OnModelCreating(DbModelBuilder mb)
    {
        mb.Entity<YogaSpace>().HasMany(p => p.Images )
            .WithRequired()
            .HasForeignKey(c => c.YogaSpaceImageId)
            .WillCascadeOnDelete();
    } 
