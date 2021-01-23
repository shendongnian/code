    using ProjectName.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.ModelConfiguration;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class ProfileMapping : EntityTypeConfiguration<Profile>
    {
        public ProfileMapping()
        {
            // Primary Key
            this.HasKey(t => t.Id);
            // Map POCO name to Column Name
            this.Property(t => t.Firstname)
                .HasColumnName("First_Name")
                .HasMaxLength("256");
            // Table Mapping
            this.ToTable("Profiles");
            // Relationships
            this.HasRequired(t => t.Roles);
        }
    }
