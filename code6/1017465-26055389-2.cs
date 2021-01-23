    internal partial class CountryConfiguration : EntityTypeConfiguration<Country>
        {
            public CountryConfiguration()
            {
                ToTable("dbo.Country");
                HasKey(x => x.Country_Id);
    
                Property(x => x.Country_Id).HasColumnName("Country_Id").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
                Property(x => x.Country_Name).HasColumnName("Country_Name").IsOptional().HasMaxLength(255);
            }
    }
    internal partial class StateConfiguration : EntityTypeConfiguration<State>
    {
            public StateConfiguration()
            {
                ToTable("dbo.State");
                HasKey(x => x.State_Id);
    
                Property(x => x.State_Id).HasColumnName("State_Id").IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
                Property(x => x.State_Name).HasColumnName("State_Name").IsOptional().HasMaxLength(255);
               	// Foreign keys
                HasOptional(a => a.Country).WithMany(b => b.States).HasForeignKey(c => c.CountryId); 
    		}
    }
