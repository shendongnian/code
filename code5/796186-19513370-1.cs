    modelbuilder.Entity<Room>()
                .HasKey(o => new { o.ID, o.HouseId });
    modelbuilder.Entity<Room>()
                .Property(o => o.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
