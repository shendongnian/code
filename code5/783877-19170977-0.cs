        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
                modelBuilder.Entity<User>()
                        .Property(p => p.CreatedDate )
                        .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed);
        }
