     public class EmployeeMap : EntityTypeConfiguration<Employee>
        {
            public EmployeeMap()
            {
                // Primary Key
                this.HasKey(t => t.EmployeeUUID);
    
    
                this.Property(t => t.SSN)
                    .IsRequired()
                    .HasMaxLength(11);
    
                this.Property(t => t.LastName)
                    .IsRequired()
                    .HasMaxLength(64);
    
                this.Property(t => t.FirstName)
                    .IsRequired()
                    .HasMaxLength(64);
    
                // Table & Column Mappings
                this.ToTable("Employee");
                this.Property(t => t.EmployeeUUID).HasColumnName("EmployeeUUID");
    
                this.Property(t => t.SSN).HasColumnName("SSN");
                this.Property(t => t.LastName).HasColumnName("LastName");
                this.Property(t => t.FirstName).HasColumnName("FirstName");
                this.Property(t => t.CreateDate).HasColumnName("CreateDate");
                this.Property(t => t.HireDate).HasColumnName("HireDate");
    
    
    
                this.Ignore(t => t.SomeNonTrackedDatabaseProperty);
    
    
            }
        }
    }
    	
