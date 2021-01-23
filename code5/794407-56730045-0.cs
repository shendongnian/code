    protected override void OnModelCreating(ModelBuilder builder)
    {
         builder.Entity<ApplicationRole>(entity =>
         {
             entity.ToTable(name:"Role");
             entity.Property(e => e.Id).HasColumnName("RoleId");
          });
    }
