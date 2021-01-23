    modelBuilder.Entity<Contacts>()
                .HasMany(e => e.ContactMatches1)
                .WithRequired(e => e.Contact1)
                .HasForeignKey(e => e.Id);
            modelBuilder.Entity<Contacts>()
                .HasMany(e => e.ContactMatches2)
                .WithRequired(e => e.Contact2)
                .HasForeignKey(e => e.Id);
