            modelBuilder.Entity<Word>()
                  .HasMany(w => w.WordTypes)
                  .WithMany(wt => wt.Words)
                  .Map(x =>
                       {
                          x.ToTable("WordWordType"); 
                          x.MapLeftKey("WordId");
                          x.MapRightKey("WordTypeId");
                       });
