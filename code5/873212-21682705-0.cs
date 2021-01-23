    public class EntityTypeMap : EntityTypeConfiguration<EntityType>
    {
        public EntityTypeMap()
        {
            HasKey(t => t.Id);
    
            HasOptional(t => t.Entity)
               .WithMany()
               .HasForeignKey(t => t.EntityId);
        }
    }
