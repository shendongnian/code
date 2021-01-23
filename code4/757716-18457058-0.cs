    string queryString = "Select friendshipstatus from tblfriend where username = @username and friend = @friend";
    using (SqlConnection connection = new SqlConnection(connectionString))
    using (SqlCommand command = new SqlCommand(queryString, connection))
    {
        command.Parameters.AddWithValue("@username", username);
        command.Parameters.AddWithValue("@friend", friend);
    
        connection.Open();
        using (SqlDataReader reader = command.ExecuteReader())
        {
            while (reader.Read()) // you have matching record if this condition true 
            {
                string friendship = reader.GetString(0); // get the value of friendshipstatus 
            }
        }
    }
