    try
    {
    	using (var sc = new OleDbConnection("[YOUR_CONNECTION_STRING]"))
    	{
    		using (var read = new OleDbCommand())
    		{
    			read.Connection = sc;
    			if (counter == 1)
    			{
    				//set up insert command
    				//parameterize it
    			}
    			if (counter == 2)
    			{
    				//set up update command
    				//see my suggestion above on how this should be parameterized
    			}
    			
    			sc.Open();
    			
    			//your command doesn't return any results, so why use read.ExecuteReader()?
    			//read.ExecuteNonQuery() will work fine for your purposes and doesn't instantiate
    			//another object
    			var rowsAffected = read.ExecuteNonQuery();
    		}
    		//at this point, regardless of whether you encounter an error, your command object is cleaned up
    	}
    	//now your connection is automatically closed/disposed of properly, again regardless of whether
    	//you encounter an error
    }
    catch(Exception ex)
    {
    	MessageBox.Show(ex.Message);
    }
