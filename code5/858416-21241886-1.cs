    modelBuilder.Entity<Grade>()
        .HasMany(g => g.EligibleGrades)
        .WithMany() // <- parameterless because there's no 2nd (inverse) collection
        .Map(m =>
        {
            m.ToTable("TBLGRADESRELATIONSHIPS");
            m.MapLeftKey("GRADEID");
            m.MapRightKey("ELIGIBLEGRADEID");
        });
