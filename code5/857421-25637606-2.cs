    public MetadataWorkspace GetWorkspace(Assembly assembly)
    {
        MetadataWorkspace result = null;
        //if (!mCache.TryGetValue(assembly, out result) || result == null)
        {
            result = new MetadataWorkspace(
                new string[] { "res://*/" },
                new Assembly[] { assembly });
            //mCache.TryAdd(assembly, result);
        }
        return result;
    }
    public ObjectContext GetObjectContext(Assembly assembly, SqlConnection conn)
    {
        var workspace = GetWorkspace(assembly);
        var entityConnection = new EntityConnection(workspace, conn);
        var context = new ObjectContext(entityConnection);
        mDisposables.Add(entityConnection);
        mDisposables.Add(context);
        return context;
    }
...
    using(var conn = new SqlConnection("..."))
    {
      conn.Open();
      using(var tr = conn.BeginTransaction())
      {
        using(var dbc1 = new DbContext1(
           GetObjectContext(typeof(DbContext1).Assembly, conn), false))
        {
          dbc1.UseTransaction(tr);
          // fetch and modify data
          dbc1.SaveChanges();
        }
        using(var dbc2 = new DbContext2(
           GetObjectContext(typeof(DbContext2).Assembly, conn), false))
        {
          dbc2.UseTransaction(tr);
          // fetch and modify data
          dbc2.SaveChanges();
        }
      }
    }
