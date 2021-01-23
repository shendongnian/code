    string query =
      "INSERT INTO PackingSession (packingDate, packingLocation, volunteerNeeded) " + 
      "VALUES (@Date, @Location, @VolunteerNeeded)";
    using (SqlConnection connection = new SqlConnection(connectionString)) {
      using (SqlCommand command = new SqlCommand(query, connection)) {
        command.Parameters.AddWithValue("@Date", date);
        command.Parameters.AddWithValue("@Location", location);
        command.Parameters.AddWithValue("@VolunteerNeeded", volunteerNeeded);
        connection.Open();
        result = command.ExecuteNonQuery();
        connection.Close();
      }
    }
