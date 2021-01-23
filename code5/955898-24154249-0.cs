    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CheckOut>().HasRequired(c => c.Analysis).WithOptional(a => a.CheckedOutBy);
        modelBuilder.Entity<Analysis>().HasMany(a => a.CheckOuts).WithRequired(c => c.AnalysisMany);
    }
