    // Configure User_Id as PK for TimelineVolumetry
        modelBuilder.Entity<TimelineVolumetry>()
            .HasKey(e => e.User_Id);
      // Configure User_Id as FK for TimelineVolumetry
        modelBuilder.Entity<User>()
                    .HasOptional(s => s.TimelineVolumetry) // Mark TimelineVolumetry is optional for User
                    .WithRequired(ad => ad.User); // Create inverse relationship
