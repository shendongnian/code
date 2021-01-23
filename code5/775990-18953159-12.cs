    public class Entity1Map : EntityTypeConfiguration<Entity1>
    {
        public Entity1Map()
        {
            this.HasKey(e => e.Entity1ID);
            this.Property(e => e.Entity1ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Map(m =>
                {
                    m.ToTable("Entity1");
                    m.MapInheritedProperties();
                });
        }
    }
    public class Entity2Map : EntityTypeConfiguration<Entity2>
    {
        public Entity2Map()
        {
            this.HasKey(e => e.Entity2ID);
            this.Property(e=> e.Entity2ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Map(m =>
                {
                    m.ToTable("Entity2");
                    m.MapInheritedProperties();
                });
        }
    }
