    modelBuilder.Entity<Project>()
                    .HasMany(p => p.Suppliers)
                    .WithMany(s => s.Projects)
                    .Map(map =>
                    {
                        map.ToTable("Project_Supplier_Map")
                           .MapLeftKey("SupplierId")
                           .MapRightKey("ProjectId");
                    });
    
