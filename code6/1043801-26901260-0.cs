    modelBuilder.Entity<Document>().Map<Licence>(map =>
    {
        map.Property(l => l.LicenceNumber).HasColumnName("Number");
        map.Property(l => l.ExpiryDate).HasColumnName("ExpiryDate");
    });
