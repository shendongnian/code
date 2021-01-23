    class Connection
    {
        public static OracleConnection Connection(string Source, string Name, string pass)
        {
            OracleConnection conn = null;
			
			try			
			{
              if(!string.IsNullOrWhiteSpace(Source) && !string.IsNullOrWhiteSpace(Name) && !string.IsNullOrWhiteSpace(pass))
                 {
                    conn = new OracleConnection("Data Source=" + Source + ";User Id=" + Name + ";Password=" + pass + ";");                  
                 }				
			  return con;
			}
			Catch(Exception exception)
			{
				//Error has occured when trying to establish Oracle connection with user credentials
			}           
        }
    }
