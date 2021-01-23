            // Person
            modelBuilder.Entity<Person>().HasKey(e => e.PersonID)
                                         .ToTable("Persons")
                                         .Property(e => e.PersonID)
                                         .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            //Referancial
            modelBuilder.Entity<Referancial>().HasKey(e => e.KeyID)
                                              .ToTable("Referancials")
                                              .Property(e => e.KeyID)
                                              .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            //Translation
            modelBuilder.Entity<Translation>().ToTable("Translations")
                                              .HasKey(e => e.KeyID)
                                              .Property(e => e.KeyID)
                                              .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<Referancial>()
                        .HasOptional(e=>e.Translations)
                        .WithMany()
                        .HasForeignKey(e => e.KeyID);
            base.OnModelCreating(modelBuilder);
        }
