    object Project_listResult = null;
    object User_profileResult = null;
    using (SqlConnection myConnection = new SqlConnection(connectionString))
            {
    
                myConnection.Open();
                SqlCommand myCommand = new SqlCommand(select, myConnection);
                myCommand.Parameters.AddWithValue("@ProjectId", querystring);
                Project_listResult = myCommand.ExecuteScalar();
            }
    
    
            string getProfileId = "SELECT ProfileId FROM User_Profile WHERE UserId = (@UserId)";
            using (SqlConnection myConnection = new SqlConnection(connectionString))
            {
                myConnection.Open();
                SqlCommand myCommand = new SqlCommand(getProfileId, myConnection);
                myCommand.Parameters.AddWithValue("@UserId", currentUserId);
                User_profileResult= myCommand.ExecuteScalar();
            }
    
    
            if (Project_listResult.Equals(User_profileResult))
            {
                addFollowerButton.Visible = true;
    
            }
