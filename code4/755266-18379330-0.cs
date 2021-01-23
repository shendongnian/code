        private string GetPreviousSession(string userID)
        {
            string prevSessionVar = "";
	        string connectionString = "your connection string to the db goes here";
	        using (SqlConnection connection = new SqlConnection(connectionString))
	        {
	            connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT TOP 1 SessionVar FROM UserSessions WHERE UserID = @UID ORDER BY InsertionDate DESC", connection))
	            {
		            command.Parameters.Add(new SqlParameter("UID", userID));
		            SqlDataReader reader = command.ExecuteReader();
		            while (reader.Read())
		            {
		                prevSessionVar = reader.GetString(0);
		            }
	            }
	        }
            return prevSessionVar;
        }
