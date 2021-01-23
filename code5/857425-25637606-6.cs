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
			using(var entityConnection1 = new EntityConnection(
				GetWorkspace(typeof(DbContext1).Assembly), conn))
		  {
			using(var context1 = new ObjectContext(entityConnection1))
			{
			  using(var dbc1 = new DbContext1(context1, false))
			  {
				using(var entityConnection2 = new EntityConnection(
					GetWorkspace(typeof(DbContext2).Assembly), conn))
				{
					using(var context2 = new ObjectContext(entityConnection2))
					{
					  using(var dbc2 = new DbContext2(context2, false))
					  {
						try
						{
							dbc1.UseTransaction(tr);
							// fetch and modify data
							dbc1.SaveChanges();
							
							dbc2.UseTransaction(tr);
							// fetch and modify data
							dbc2.SaveChanges();
							
							tr.Commit();
						}
						catch
						{
							tr.Rollback();
						}
					  }
					}
				  }
			  }
			}
		  }
      }
    }
