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
        var type = asm.GetType(et.FullName);
        Console.WriteLine("{0}: {1}", et.FullName,
          string.Join(", ", et.Members.Select(m => m.Name).ToArray()));
        var dbEntries = ctx.Set(type).AsNoTracking().AsQueryable();
        foreach (var e in dbEntries)
        {
          var propValues = et.Members
            .Select(m => type.GetProperty(m.Name).GetValue(e).ToString())
            .ToArray();
          Console.WriteLine(" {0}", string.Join(", ", propValues));
        }
      }
    }
