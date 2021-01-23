    modelBuilder.Entity<Entity>().Map(m => m.ToTable("Entity"));
    
    modelBuilder.Entity<ConcreteEntity>().Map(m => 
    {
        m.ToTable("ConcreteEntity");
        m.Requires("IsDeleted").HasValue(false);
    });
