    public void WILF(string whatIsPlaying)
    {
        using (SqlConnection con = new SqlConnection(conString))
        {
            con.Open();
            using (var cmd = con.CreateCommand())
            {
                cmd.CommandText = "WatchedLast";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@a", whatIsPlaying);
                cmd.Parameters.AddWithValue("@b", Variables.UserId);
                cmd.ExecuteNonQuery();
            }
        }
    }
