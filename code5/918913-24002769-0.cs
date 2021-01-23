    public class ConvertCarbMap : EntityTypeConfiguration<ConvertCarb>
    {
    public ConvertCarbMap()
    {
        // Primary Key
        this.HasKey(t => t.ConvertCarbID);
        // Properties
        this.HasKey(t => t.ConvertCarbID)
            .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
        // Table & Column Mappings
        this.ToTable("ConvertCarb");
        this.Property(t => t.ConvertCarbID).HasColumnName("ConvertCarbID");
        this.Property(t => t.CountryID).HasColumnName("CountryID");
        this.Property(t => t.StateProvID).HasColumnName("StateProvID");
        this.Property(t => t.KWH_FT2).HasColumnName("KWH_FT2");
        this.Property(t => t.G_KWH).HasColumnName("G_KWH");
        this.Property(t => t.NatGas_GJ_M2).HasColumnName("NatGas_GJ_M2");
        this.Property(t => t.FuelOil_GJ_M2).HasColumnName("FuelOil_GJ_M2");
        // Relationships
        this.HasOptional(t => t.Country)
            .WithMany(t => t.ConvertCarbs)
            .HasForeignKey(d => d.CountryID);
        this.HasRequired(t => t.StateProvince)
            .WithOptional(t => t.ConvertCarb);
    }
