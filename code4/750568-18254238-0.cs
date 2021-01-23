    string connectionString = "";
    string queryString = "";
    using (var connection = new SqlConnection(connectionString))
    using (var command = new SqlCommand(queryString, connection))
    {
        try
        {
            connection.Open();
            using (SqlDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    // Note that reader[x] has the equivalent type to the type
                    // of the returned column, converted using
                    // http://msdn.microsoft.com/en-us/library/cc716729.aspx
                    // .ToString() if the item isn't null is always ok
                    string SessionIDstring = reader[0].ToString(); // it should be an int
                    // reading it twice is ok
                    int RoomID = (int)reader[1]; // it should be an int
                    string RoomIDstring = reader[1].ToString(); // it should be an int
                    if (reader.Read())
                    {
                        throw new Exception("Too many rows");
                    }
                }
                else 
                {
                    throw new Exception("No rows");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
