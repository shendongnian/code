    modelBuilder.Entity<TableABC>().Property(t => t.Name).HasColumnName("name");
    modelBuilder.Entity<TableABC>().Property(t=>t.Surname).HasColumnName("surname");
    modelBuilder.Entity<TableABC>()
        .HasMany(t => t.Colours).WithRequired().HasForeignKey(c => c.Id);
    modelBuilder.Entity<TableABC>()
        .HasMany(t => t.Pets).WithRequired().HasForeignKey(p => p.Id);
    
    modelBuilder.Entity<Colour>().Property(c => c.Value).HasColumnName("colours");
    modelBuilder.Entity<Colour>().HasKey(c => new { c.Id, c.Value });
    modelBuilder.Entity<Pet>().Property(p => p.Name).HasColumnName("pets");
    modelBuilder.Entity<Pet>().HasKey(c => new { c.Id, c.Name });
