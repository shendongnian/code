     modelBuilder.Entity<Grade>()
                        .HasKey(g => g.GradeKey)
                        .HasMany(g => g.Tests)
                        .WithMany(t => t.Grades)
                        .Map(map =>
                            {
                                map.ToTable("GradeTests");
                                map.MapLeftKey("GradeKey");
                                map.MapRightKey("TestKey");
                            });
