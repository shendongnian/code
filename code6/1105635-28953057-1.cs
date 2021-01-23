    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    
        modelBuilder.Entity<RelatedEntity>().HasKey(e => e.PrimaryEntityId);    
        modelBuilder.Entity<RelatedEntity>().HasRequired(re => re.Primary).WithOptional(pe => pe.Related);
    }
