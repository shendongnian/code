    public override int SaveChanges()
    {
       var changeSet = ChangeTracker.Entries<IAuditable>();
       if (changeSet != null)
       {
          foreach (var entry in changeSet.Where(c => c.State != EntityState.Unchanged))
          {
              entry.Entity.ModifiedDate = DateProvider.GetCurrentDate();
              entry.Entity.ModifiedBy = UserName;
          }
       }
       return base.SaveChanges();
   }
