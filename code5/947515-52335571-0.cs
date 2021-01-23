    protected override void OnModelCreating(DbModelBuilder modelBuilder){
        //More stuff
        modelBuilder.Entity<Device>().Property(c => c.Name).HasColumnType("nvarchar").HasMaxLength(50);
        modelBuilder.Entity<Device>().HasIndex(c => c.Name).IsUnique(true); 
    }
