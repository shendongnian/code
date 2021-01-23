    string connectionString = "";
    // Wait for 5 second delay in the command
    string queryString = "waitfor delay '00:00:05'";
    using (OleDbConnection connection = new OleDbConnection(connectionString )) {
        connection.Open();
        SqlCommand command = new connection.CreateCommand();
        // Setting command timeout to 1 second
        command.CommandText = queryString;
        command.CommandTimeout = 1;
        try {
            command.ExecuteNonQuery();
        }
        catch (DbException e) {
            Console.WriteLine("Got expected DbException due to command timeout ");
            Console.WriteLine(e);
        }
    }
  
