    public class SomeDataMap : EntityTypeConfiguration<SomeData>
    {
        public SomeDataMap()
        {
            // Primary Key
            this.HasKey(t => t.id);
            // Properties
            this.Property(t => t.id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(t => t.reference)
                .HasMaxLength(50);
            this.Property(t => t.STag)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
        }
    }
