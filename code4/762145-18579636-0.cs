    class Connection
        {
            public static OracleConnection GetConnection(string dataSource, string userName, string password)
            {
    			OracleConnection con = null;
    			if(!string.IsNullOfEmpty(dataSource) && !string.IsNullOfEmpty(userName) && !string.IsNullOfEmpty(password))
    				{
    					con = new OracleConnection("Data Source=" + dataSource + ";User Id=" + userName.ToUpper() + ";Password=" + password + ";");
    					return con;
    				}
            }
        }
