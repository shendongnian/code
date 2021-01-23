    protected string GetStreamLocation()
    {
        int channelId;
        var success = int.TryParse(Request.QueryString["ChannelID"], out channelId);
        if (!success) throw new Exception("Invalid channel id specified");
        string returnValue;
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            using (SqlCommand cmd = new SqlCommand("SELECT Link FROM TblChannel WHERE ChannelID = @id", conn))
            {
                cmd.Parameters.Add(new SqlParameter("@id", channelID));
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    reader.Read();
                    if (reader.HasRows == true)
                    {
                        returnValue = reader["Link"].ToString();
                        reader.Close();
                    }
                }
            }
        }
        if (string.IsNullOrEmpty(returnValue)) throw new Exception("Error loading link from database");
        return returnValue;
    }
