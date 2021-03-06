    string queryString = "SELECT OrderID, CustomerID FROM dbo.Orders;";
    using (SqlConnection connection = new SqlConnection(connectionString))
    {
    SqlCommand command = new SqlCommand(queryString, connection);  //<- See here the connection is passes to the command
    connection.Open();
    SqlDataReader reader = command.ExecuteReader();
    try
    {
    	while (reader.Read())
    	{
    		Console.WriteLine(String.Format("{0}, {1}",
    			reader[0], reader[1]));
    	}
    }
    finally
    {
    	// Always call Close when done reading.
    	reader.Close();
    }
    }
