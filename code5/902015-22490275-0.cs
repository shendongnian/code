    dbContext.Entry(registerType).State = EntityState.Modified;
    forech (var f in registerType.Fields)
    {
        dbContext.Entry(f).State = ( f.Id == default(int) ? EntityState.Added : EntityState.Modified);
    }
