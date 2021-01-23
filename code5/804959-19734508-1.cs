    using (var connection = new SqlConnection(connectionString))
    {
      using (var command = new SqlCommand("UpdateVolunteers", connection))
      {
        command.Parameters.AddWithValue("@Vol_ID", volID);
        // other paramters...
        
        connection.Open();
        command.ExecuteNonQuery();
      }
    }
