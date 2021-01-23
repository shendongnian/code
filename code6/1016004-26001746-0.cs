    using (SqlConnection con = new SqlConnection(cs))
    {
        // Configure the SqlCommand and SqlParameter.
        SqlCommand sqlCmd = new SqlCommand("dbo.SaveResults", con);
        sqlCmd.CommandType = CommandType.StoredProcedure;
    
        SqlParameter tvpParam = sqlCmd.Parameters.AddWithValue("@positiveResults", dtResults); 
        
        //tell compiler that we are passing TVP
        tvpParam.SqlDbType = SqlDbType.Structured; 
    
        sqlCmd.Parameters.Add(new SqlParameter("@resultID", id));
        sqlCmd.ExecuteNonQuery();
    }
