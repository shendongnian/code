    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
         modelBuilder.Entity<C>().HasRequired(c => c.A).WithMany(a => a.Cs).HasForeignKey(c => c.AID);
         modelBuilder.Entity<C>().HasRequired(c => c.B).WithMany(b => b.Cs).HasForeignKey(c => c.BID);
    }
