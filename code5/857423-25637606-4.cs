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
...
    using(var conn = new SqlConnection("..."))
    {
      conn.Open();
      using(var tr = conn.BeginTransaction())
      {
        using(var entityConnection = new EntityConnection(GetWorkspace(typeof(DbContext1).Assembly), conn))
        {
          using(var context = new ObjectContext(entityConnection))
          {
            using(var dbc1 = new DbContext1(context, false))
            {
              dbc1.UseTransaction(tr);
              // fetch and modify data
              dbc1.SaveChanges();
            }
          }
        }
        using(var entityConnection = new EntityConnection(GetWorkspace(typeof(DbContext2).Assembly), conn))
        {
          using(var context = new ObjectContext(entityConnection))
          {
            using(var dbc2 = new DbContext2(context, false))
            {
              dbc2.UseTransaction(tr);
              // fetch and modify data
              dbc2.SaveChanges();
            }
          }
        }
      }
    }
