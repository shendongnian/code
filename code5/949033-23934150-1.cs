    foreach (DecodedShortMessage message in messages) {
        using (SqlCommand command = new SqlCommand("INSERT INTO SMSArchives (Message, Blacklist) VALUES (@par, 'Yes')", , connection)) {
           command.Parameters.AddWithValue("@par", message.ToString());
           command.ExecuteNonQuery(); 
        }
    }
