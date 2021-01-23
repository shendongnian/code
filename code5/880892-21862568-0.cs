    using (var connection = new SqlConnection("<Your connection string here>")
    {
        var command = new SqlCommand(
          "SELECT username, email FROM users;",
          connection);
        connection.Open();
        var reader = command.ExecuteReader(); // Using the DataReader (specifically, the SqlDataReader)
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                Console.WriteLine("User {0} has email {1}", reader["username"],
                    reader["email"]);
            }
        }
        else
        {
            Console.WriteLine("No rows found.");
        }
        reader.Close();
    }
