    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.Entity<Account>()
                .ForRelational(builder => builder.Table("Account"))
                .Property(value => value.Username).MaxLength(50)
                .Property(value => value.Email).MaxLength(255)
                .Property(value => value.Name).MaxLength(255);
        }
