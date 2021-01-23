    public class PatientMap: EntityTypeConfiguration<Patient>
    {
        public PatientMap()
        {
            //table
            this.ToTable("TBL_PATIENTS", "dbo");
            //PK
            this.HasKey(t => t.id);
            //Columns
            this.Property(t => t.forenames)
                .HasColumnName("FIRSTNAMES")
                .IsRequired()
                .HasMaxLength(50);
            // Relationships
            this.HasRequired(t => t.Ward)
                .WithMany(t => t.Patients)
                .HasForeignKey(d => d.Ward_id);
        }
    }
