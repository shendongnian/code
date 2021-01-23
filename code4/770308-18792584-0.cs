    public class ReportMap : EntityTypeConfiguration<Report>
        {
            public ReportMap()
            {
                // Primary Key
                this.HasKey(t => t.Id);
    
                // Properties
                this.Property(t => t.ReportName)
                    .IsRequired()
                    .HasMaxLength(100);
    
                // Table & Column Mappings
                this.ToTable("Reports");
                this.Property(t => t.Id).HasColumnName("Id");
                this.Property(t => t.ReportName).HasColumnName("ReportName");
    
                // Relationships
                this.HasRequired(t => t.Product)
                    .WithMany(t => t.ProductReports)
                    .HasForeignKey(d => d.ProductId);
            }
        }
