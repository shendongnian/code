    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        modelBuilder.Entity<Entity1>()
            .HasMany(b => b.Entities2)
            .WithMany(p => p.Entities1)
            .Map(m =>
            {
                m.ToTable("Entitie1Entity2");
                m.MapLeftKey("Entity1Id");
                m.MapRightKey("Entity2Id");
            });            
        }
