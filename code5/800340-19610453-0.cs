    private void MyRule() 
    {
      DateTime saveTime = DateTime.Now;
        foreach (var entry in this.ChangeTracker.Entries().Where(e => e.State == System.Data.EntityState.Added))
        {
            if (entry.Property("CreateDate").CurrentValue == null)
                entry.Property("CreateDate").CurrentValue = saveTime;
        }
     }
