    protected override void OnModelCreating(DbModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder);
    
                modelBuilder.Properties().Where(p => p.Name.ToLower().Contains("id"))
                        .Configure(p => p.HasDatabaseGeneratedOption(DatabaseGeneratedOption.None));
            }
