    public override int SaveChanges()
    {
      DateTime saveTime = DateTime.Now;
      foreach (var entry in this.ChangeTracker.Entries().Where(e => e.State == System.Data.EntityState.Added))
       {
         if (entry.Property("dateCreated").CurrentValue == null)
           entry.Property("dateCreated").CurrentValue = saveTime;
        }
        return base.SaveChanges();
    
    }
