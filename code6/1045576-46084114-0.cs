    class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
      public void Configure(EntityTypeBuilder<Customer> builder)
      {
         builder.HasKey(c => c.AlternateKey);
         builder.Property(c => c.Name).HasMaxLength(200);
       }
    }
    
    ...
    // OnModelCreating
    builder.ApplyConfiguration(new CustomerConfiguration());
