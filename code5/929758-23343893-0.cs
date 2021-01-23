    using (ISession session = sessionFactory.OpenSession())
    {
    	using (FileStream strm = File.OpenRead("Seed.sql"))
    	{
    		using (var reader = new StreamReader(strm))
    		{
    			string sqlDelete = reader.ReadToEnd();
    
    			try
    			{
    				IQuery query = session.CreateSQLQuery(sqlDelete);
    				query.ExecuteUpdate();
    			}
    			catch (Exception ex)
    			{
    				log.Fatal(ex.ToString());
    			}
    		}
    	}
    }
