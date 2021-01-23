    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Properties<DateTime>().Configure(c => c.HasColumnType("datetime2"));
        modelBuilder.Entity<Account>().HasMany(x => x.Payments)
            .WithMany().Map(t => t.ToTable("AccountPayments"));
        modelBuilder.Entity<Payment>().HasMany(x => x.Products)
            .WithMany().Map(t => t.ToTable("PaymentProducts"));
        modelBuilder.Entity<Payment>().HasOptional(x => x.AccountID);
        modelBuilder.Entity<Payment>().HasKey(x => x.PaymentID);
    }
