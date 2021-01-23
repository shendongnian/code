        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            if(allowIdentityInsert)
            {
                modelBuilder.Entity<ChargeType>()
                    .Property(x => x.Id)
                    .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            }
        }
