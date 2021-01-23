    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
       modelBuilder.Entity<ContractMedia>()
           .HasKey(c => new { c.MediaId, c.ContractId });
       modelBuilder.Entity<Contract>()
           .HasMany(c => c.ContractMedias)
           .WithRequired()
           .HasForeignKey(c => c.ContractId);
       modelBuilder.Entity<Media>()
           .HasMany(c => c.ContractMedias)
           .WithRequired()
           .HasForeignKey(c => c.MediaId);  
    }
