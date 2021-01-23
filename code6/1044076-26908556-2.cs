    public int UserId{get; set;}
    
    public override int SaveChanges()
    {
        this.ChangeTracker.DetectChanges();
        var added = this.ChangeTracker.Entries()
                   .Where(t => t.State == EntityState.Added)
                   .Select(t => t.Entity)
                   .ToArray();
        foreach(var entity in added)
           if(entity is ITrack)
           {
               var track=entity as ITrack;
               track.CreatedDate=DateTime.Now;
               track.CreatedBy=UserId;
           }
        var modified = this.ChangeTracker.Entries()
                   .Where(t => t.State == EntityState.Modified)
                   .Select(t => t.Entity)
                   .ToArray();
        foreach(var entity in added)
           if(entity is ITrack)
           {
               var track=entity as ITrack;
               track.ModifiedDate=DateTime.Now;
               track.ModifiedBy=UserId;
           }
    }
