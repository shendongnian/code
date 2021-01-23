    using (SqlConnection cnn = new SqlConnection("yourConnectionString"))
    {
        string sql= "select userId,role from users " +
                    "where username=@uName and password=@pWord";
    
        using (SqlCommand cmd = new SqlCommand(sql,cnn))
        {
             cmd.Parameters.AddWithValue("@uName", username);
             cmd.Parameters.AddWithValue("@pWord", pwd);
    
             cnn.Open();
             SqlDataReader reader = command.ExecuteReader();
    
             while (reader.Read())
             {
                //get the reader values here.
             }
        }
    }
