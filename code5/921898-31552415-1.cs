    public class CarrierMap : EntityTypeConfiguration<Carrier>
    {
        public CarrierMap()
        {
            HasKey(p => p.Id);
            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(p => p.Code)
                .HasMaxLength(4)
                .IsRequired()
                .HasColumnAnnotation("Index", new IndexAnnotation(new IndexAttribute { IsClustered = true, IsUnique = true }));
            Property(p => p.Name).HasMaxLength(255).IsRequired();
            Property(p => p.Created).HasPrecision(7).IsRequired();
            Property(p => p.Modified)
                .HasColumnAnnotation("IX_Modified", new IndexAnnotation(new IndexAttribute()))
                .HasPrecision(7)
                .IsRequired();
            Property(p => p.CreatedBy).HasMaxLength(50).IsRequired();
            Property(p => p.ModifiedBy).HasMaxLength(50).IsRequired();
            Property(p => p.Version).IsRowVersion();
        }
    }
