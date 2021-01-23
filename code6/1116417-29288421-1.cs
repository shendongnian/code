    modelBuilder.Entity<Movies>().HasMany(m => m.Genres)
                                 .WithMany(g =>g.Movies)
                                 .Map(c =>{  c.MapLeftKey("MovieId");
                                             c.MapRightKey("GenreId");
                                             c.ToTable("MovieGenres");
                                          });
