    public void ReadMyData(string connectionString)
    {
        string queryString = "SELECT OrderID, CustomerID FROM Orders";
        using (OleDbConnection connection = new OleDbConnection(connectionString))
        {
            using (OleDbCommand command = new OleDbCommand(queryString, connection))
            {
                connection.Open();
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Console.WriteLine(reader.GetInt32(0) + ", " + reader.GetString(1));
                    }
                }
            }
        }
    }
