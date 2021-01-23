        class Connection
        {
            public static OracleConnection GetConnection(string dataSource, string userName, string password)
            {
				OracleConnection con = null;
				if(!string.IsNullOrWhiteSpace(dataSource) && !string.IsNullOrWhiteSpace(userName) && !string.IsNullOrWhiteSpace(password))
					{
						con = new OracleConnection("Data Source=" + dataSource + ";User Id=" + userName.ToUpper() + ";Password=" + password + ";");
						return con;
					}
					
				return con;
            }
        }
