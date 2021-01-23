    public PocoWithDatesContext : DbContext
    {
         public DbSet<PocoWithDates> PocoWithDatesSet { get; set;}
    
         public override int SaveChanges()
         {
             this.ChangeTracker.DetectChanges();
             foreach (var item in this.ChangeTracker.Entries()
                                   .Where(i => i.State == EntityState.Modified)
                                   .Where(i => i as IEntityWithDateUpdated != null))
             {
                  (item as IEntityWithDateUpdated).DateUpdated = DateTime.Now;
             }
             // Call the SaveChanges method on the context;
             return base.SaveChanges();
         }
    }
