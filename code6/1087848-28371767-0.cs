    string sendMessage = "SELECT Email, username FROM aspnet_Membership WHERE UserId = @UserId";
    using (SqlConnection myConnection = new SqlConnection(connectionString))
    using (SqlCommand myCommand = new SqlCommand(sendMessage, myConnection))
    {
        myConnection.Open();
        myCommand.Parameters.AddWithValue("@UserId", newUserId);
        using(SqlDataReader reader = myCommand.ExecuteReader())
        {
             while(reader.Read())
             {
                  label1.Text = reader.GetString(reader.GetOrdinal("EMail"));
                  label2.Text = reader.GetString(reader.GetOrdinal("UserName"));
             } 
       }
