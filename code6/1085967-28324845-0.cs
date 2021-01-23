    public void GetDbSets(DbContext ctx)
    {
      // Initialize, to build the metadata
      ctx.Database.Initialize(true);
      // Access the underlying ObjectContext
      var objectContext = ((IObjectContextAdapter)ctx).ObjectContext;
      // Get the metadata for the DbContext
      MetadataWorkspace mdw = objectContext.MetadataWorkspace;
      // get the assembly, where the entity types are defined
      var asm = ctx.GetType().Assembly;
      // Get the metadata for the entity types
      ReadOnlyCollection<EntityType> entityTypes
        = mdw.GetItems<EntityType>(DataSpace.CSpace);
      foreach (var et in entityTypes)
      {
        // get the type from the metadata and the assembly
        var type = asm.GetType(et.FullName);
        // Just to test
        Console.WriteLine(type.FullName);
        // Get the Set for the type, and query it
        var dbEntries = ctx.Set(type).AsNoTracking().AsQueryable();
        foreach (var e in dbEntries)
        {
          // here you should serialize your object, and store it where you want
          // Serialez and store "e"
        }
      }
    }
