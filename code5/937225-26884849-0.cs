    ToTable("table_name");
        HasKey(x => x.CounterId); // you should split HasKey from Property
        Property(x => x.CounterId)
            .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
            .HasColumnName("dbCounter_Id")
            .HasPrecision(10, 0)
            .IsRequired();
    
        Property(x => x.HouseId)
            .HasColumnName("dbHouseId");
    
        Property(x => x.ApplicationId)
            .HasColumnName("dbApplication_id");
