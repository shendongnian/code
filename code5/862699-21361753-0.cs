    int SetPopularity()
    {
        string qry = @"update uploadphoto set popularity=popularity+1";    
        SqlConnection conn = new SqlConnection(connString);
        SqlCommand cmd = conn.CreateCommand(qry,con);  
        conn.Open();
        int status=cmd.ExecuteNonQuery();
        conn.Close();
        return status;
    }
