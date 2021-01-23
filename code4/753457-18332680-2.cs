    public static class myMethods
    {
    	public static string getName()
    	{
    		string name = "";    
    		ConnectionStringSettings myConnectionString = ConfigurationManager.ConnectionStrings["LibrarySystem.Properties.Settings.LibraryConnectionString"];
    		using (SqlConnection myDatabaseConnection = new SqlConnection(myConnectionString.ConnectionString))
    		{
    			myDatabaseConnection.Open();
    			using (SqlCommand mySqlCommand = new SqlCommand("select Top 1 Name from Setting Order By SettingID Desc", myDatabaseConnection))
    			var NameObj = mySqlCommand.ExecuteScalar()
    			if NameObj != null then
    			  name = NameObj.ToString()
    		}
    		return name;
    	}
    }        
