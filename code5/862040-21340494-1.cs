    void MainFormLoad(object sender, EventArgs e)
    {
        var dt = new DataTable();
    	// You may want to pass other parameters to OpenText for read mode, etc.
        using (var sr = File.OpenText(@"C:\Users\rl\Desktop\TEST_I~1.CSV"))
    	{
    		var first = true;
    		string line = null;
    		
    		while ((line = sr.ReadLine()) != null)
    		{
    			string[] data = line.Split(',');
    			if (data.Length > 0)
    			{
    				if (first)
    				{
    					foreach (var item in data)
    					{
    						dt.Columns.Add(item.ToString());
    					}
    					first = false;
                        // Don't add the first row's data in the table (headers?)
                        continue; 
    				}
    				var row = dt.NewRow();
    				row.ItemArray = data;
    				dt.Rows.Add(row);
    			}
    		}
    	}
    		  
        using (var cn = new SqlConnection("<connection string>"))
    	{
    		cn.Open();
    		using (var copy = new SqlBulkCopy(cn))
    		{
    			// copy.ColumnMappings.Add(0, 0);
    			// copy.ColumnMappings.Add(1, 1);
    			// copy.ColumnMappings.Add(2, 2);
    			// copy.ColumnMappings.Add(3, 3);
    			// copy.ColumnMappings.Add(4, 4);
    			copy.DestinationTableName = "Member2";
    			copy.WriteToServer(dt);
    		}
    	}
    	
    }
