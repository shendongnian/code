    string dbfile = yourDbFile;
    using (var connection = new SqlCeConnection("datasource=" + dbfile))
    {
    	using (var adapter = new SqlCeDataAdapter("select * from [Table2]", connection))
    	{
    		using (var builder = new SqlCeCommandBuilder(adapter))
    		{
    			// The CommandBuilder automatically builds INSERT, UPDATE 
    			// and DELETE statements from the given SELECT statement.
    			// otherwise, these commands would need to be specified
    			// manually.
    			builder.RefreshSchema();
    
    			using (var data = new DataSet())
    			{
    				// Fill() opens the connection if necessary
    				adapter.Fill(data); 
    
    				// The "table", i.e. the result of the select statement,
    				// does *not* have the name "Table2".
    				// To reduce confusion, just work with the "table"
    				// at index 0.
    				var dr = data.Tables[0].NewRow();
    				dr["ID"] = 0;
    				dr["Name"] = "Jan";
    				data.Tables[0].Rows.Add(dr);
    
    				data.Tables[0].Rows.Add(new object[] { 1, "Jan" });
    				adapter.Update(data);
    			}
    		}
    	}
    }
