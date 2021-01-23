    modelBuilder.Entity<Record>()
        .ToTable("YourRecordTableName");
    modelBuilder.Entity<Record>()
        .HasKey(r => r.Ndx);
    modelBuilder.Entity<Record>()
        .Property(r => r.Ndx)
        .HasColumnName("ndx"); // probably redundant because case doesn't matter
    modelBuilder.Entity<Record>()
        .Property(r => r.CreatedAt)
        .HasColumnName("created");
    modelBuilder.Entity<Patient>()
        .ToTable("YourPatientTableName");
    modelBuilder.Entity<Patient>()
        .Property(r => r.Ndx)   // Yes, no typo: It must be Ndx, NOT RecordNdx !
        .HasColumnName("record_ndx");
    modelBuilder.Entity<Patient>()
        .Ignore(r => r.RecordNdx);
