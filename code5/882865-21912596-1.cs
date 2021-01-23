    public PocoWithDatesContext : DbContext
    {
         public DbSet<PocoWithDates> PocoWithDatesSet { get; set;}
    
         public override int SaveChanges()
         {
             this.ChangeTracker.DetectChanges();
             foreach (var item in this.ChangeTracker.Entries()
                                   .Where(i => i.State != EntityState.Unchanged)
                                   .Where(i => i as IWithDateUpdated != null))
             {
                  (item as IWithDateUpdated).DateUpdated = DateTime.Now;
             }
             // Call the SaveChanges method on the context;
             return base.SaveChanges();
         }
    }
