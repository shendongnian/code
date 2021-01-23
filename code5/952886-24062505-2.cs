    public int Update<TEntity>(TEntity domainObject)
    {
      int id = domainObject.Id; // Needs interface !!
      using (var context = new MyDbContext())
      {
        var objectInDb 
           = ctx.DbSet<TEntity>.Single(e => e.Id == id);  // Needs interface !!
        // Use ValueInjecter (not AutoMapper) to copy the properties
        objectInDb.InjectFrom(domainObject); // needs ValueInjecter Nuget Package
        context.SaveChanges();
      }
      return userId;
    }
