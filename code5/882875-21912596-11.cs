    public PocoWithDatesContext : DbContext
    {
         public DbSet<PocoWithDates> PocoWithDatesSet { get; set;}
    
         public override int SaveChanges()
         {
             var now = DateTime.Now;             
             this.ChangeTracker.DetectChanges();
             foreach (var item in this.ChangeTracker.Entries()
                                   .Where(i => i.State == EntityState.Added || i.State == EntityState.Modified)
                                   .Where(i => i as IEntityAutoDateFields != null))
             {
                 if (item.State == EntityState.Added)
                 {
                      (item as IEntityAutoDateFields).DateCreated = now;
                 }
                 (item as IEntityAutoDateFields).DateUpdated = now;
             }
             // Call the SaveChanges method on the context;
             return base.SaveChanges();
         }
    }
