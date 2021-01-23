    public ProductConfiguraton()
    {
        ToTable("t_Product");
        HasKey(p => new { p.Id, p.VersionId });
        HasRequired(p => new {p.VersionId, p.StrengthId})
            .WithMany(b => new {b.VersionId, b.Id})
            .HasForeignKey(p => p.VersionIdStrengthId);
        Property(p => p.Id).HasColumnName("iProductId");
        Property(p => p.VersionId).HasColumnName("iVersionID");
        Property(p => p.Name).HasColumnName("sName");
        Property(p => p.StrengthId).HasColumnName("iStrengthId");
    }
