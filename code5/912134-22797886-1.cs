    class Program
    {
        public void ResponseToUser(string userInput)
        {
            string connectionString = @"Your database path";
            using (OleDbConnection databaseConnection = new OleDbConnection(connectionString))
            {
                databaseConnection.Open();
                using (OleDbCommand command = new OleDbCommand("SELECT * FROM TableName", databaseConnection))
                {
                    OleDbDataReader reader = command.ExecuteReader();
                    string response = string.Empty;
                    while (reader.Read())
                    {
                        if (reader["Keyword"].ToString().Equals(userInput))
                        {
                            response = reader["Response"].ToString();
                            break;
                        }
                    }
                    reader.Close();
                } 
            }
        } 
    }
