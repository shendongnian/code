	public sealed class DbPerformer
	{
		private const string mySqlServerName = "localhost";
		private const string dataBaseName = "testdb";
		private const string uid = "login";
		private const string password = "password";
		private MySqlConnection connection;
		public DbPerformer()
		{
			string connectionString;
			connectionString = "server=" + mySqlServerName + ";";
			connectionString += "Username=" + uid + ";";
			connectionString += "Password=" + password;
			connection = new MySqlConnection(connectionString);
		}
        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        Debug.WriteLine("Cannot connect to server {0}", mySqlServerName);
                        break;
                    case 1045:
                        Debug.WriteLine("Invalid username/password.");
                        break;
                }
                return false;
            }
        }
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                Debug.WriteLine(ex.Message);
                return true;
            }
        }
		public List<object[]> ExecuteSelectQuery(string selectQuery)
		{
			List<object[]> resultList = new List<object[]>();
			if (true == this.OpenConnection())
			{
				MySqlCommand command = new MySqlCommand(selectQuery, connection);
				MySqlDataReader resultReader = command.ExecuteReader();
				while (resultReader.Read())
				{
					object[] resultRow = new object[resultReader.FieldCount];
					resultReader.GetValues(resultRow);
					resultList.Add(resultRow);
				}
				resultReader.Close();
				this.CloseConnection();
			}
			else
			{
				throw new Exception("Can not open connection to database.");
			}
			return resultList;
		}
	}
