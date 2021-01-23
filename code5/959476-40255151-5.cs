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
            // Then add the following bit
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
    //Add this for Identity Insert
    /// <summary>
    /// Enable Identity insert for specified entity type.
    /// Note you should wrap the identity insert on, the insert and the identity insert off in a transaction
    /// </summary>
    /// <typeparam name="T">Entity Type</typeparam>
    /// <param name="On">If true sets identity insert on else set identity insert off</param>
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
    //Add this for Rollback changes
    /// <summary>
    /// Rolls back pending changes in all changed entities within the DB Context
    /// </summary>
    public void RollBack()
    {
        var changedEntries = ChangeTracker.Entries()
            .Where(x => x.State != EntityState.Unchanged).ToList();
        foreach (var entry in changedEntries)
        {
            switch (entry.State)
            {
                case EntityState.Modified:
                    entry.CurrentValues.SetValues(entry.OriginalValues);
                    entry.State = EntityState.Unchanged;
                    break;
                case EntityState.Added:
                    entry.State = EntityState.Detached;
                    break;
                case EntityState.Deleted:
                    entry.State = EntityState.Unchanged;
                    break;
            }
        }
    }
