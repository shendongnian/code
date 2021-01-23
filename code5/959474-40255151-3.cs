    public MyDBContext(bool _EnableIdentityInsert)
        : base("name=ConnectionString")
    {
        EnableIdentityInsert = _EnableIdentityInsert;
    }
    private bool EnableIdentityInsert = false;
    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DBContextIMD, Configuration>());
            //modelBuilder.Entity<SomeEntity>()
            //    .Property(e => e.SomeProperty)
            //    .IsUnicode(false);
            // Etc... Configure your model
            // Then do add the following bit
        if (EnableIdentityInsert)
        {
            modelBuilder.Entity<SomeEntity>()
                .Property(x => x.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            modelBuilder.Entity<AnotherEntity>()
                .Property(x => x.ID)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        }
    }
    //Finally add this
    public void IdentityInsert<T>(bool On)
        where T: class
    {
        if (!EnableIdentityInsert)
        {
            throw new NotSupportedException(string.Concat(@"Cannot Enable entity insert on ", typeof(T).FullName, @" when _EnableIdentityInsert Parameter is not enabled in constructor"));
        }
        if (On)
        {
            Database.ExecuteSqlCommand(string.Concat(@"SET IDENTITY_INSERT ", this.GetTableName<T>(), @" ON"));
        }
        else
        {
            Database.ExecuteSqlCommand(string.Concat(@"SET IDENTITY_INSERT ", this.GetTableName<T>(), @" OFF"));
        }
    }
