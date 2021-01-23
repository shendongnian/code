    [WebMethod]
    public int SetPopularity(string hawkername)
    {
        string qry = @"update uploadphoto set popularity=popularity+1 
                       WHERE hawkername=@hawk";
        using(SqlConnection conn = new SqlConnection(connString))
        using(SqlCommand cmd = conn.CreateCommand(qry, conn))
        {
            conn.Open();
            cmd.Parameters.AddWithValue("@hawk", hawkername);
            int status = cmd.ExecuteNonQuery();
            return status;
         }
    }
