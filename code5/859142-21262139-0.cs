    string dateString;
    using (IDbConnection connection = new MySqlConnection()) {
        connection.ConnectionString = "YOUR STRING";
        connection.Open();
        try {
            using (IDbCommand command = connection.CreateCommand())
            {
                command.CommandText = "SELECT DATE_FORMAT(X, '%Y/%m/%d') AS  X FROM Y";
                using (IDataReader reader = command.ExecuteReader()) {
                    dateString = reader.GetString(0);
                    // Alternately you can read the data as a DateTime and use
                    // .NET's formatting.
                    //dateString = reader.GetDateTime(0).ToShortDateString();
                }
            }
        }
        finally {
            connection.Close();
        }
    }
