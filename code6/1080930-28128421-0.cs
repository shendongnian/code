    string security = @"SELECT pl.ProjectId 
                        FROM Project_List pl
                             INNER JOIN User_Profile up
                             ON up.ProfileID = pl.ProfileID 
                         WHERE up.UserId = @UserId 
                           AND pl.ProjectID = @pid";
    using (SqlConnection myConnection = new SqlConnection(connectionString))
    using (SqlCommand myCommand = new SqlCommand(security, myConnection))
    {
        myConnection.Open();
        myCommand.Parameters.AddWithValue("@UserId", currentUserId);
        myCommand.Parameters.AddWithValue("@pid", 
                     Convert.ToInt32(Request.QueryString["ProjectID"]));
        // Now, if ExecuteScalar returns null then there are no 
        // Projects for that UserID
        object result = myCommand.ExecuteScalar();
        if(result == null)
            // No projectid for the user profile
        else
            // You have one or more projectids for this user profile
    }
