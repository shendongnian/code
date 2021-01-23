    public int SubmissionInsert(string title, byte[] slides, byte[] codes)
    {
        int nofRow;
        string query = "INSERT  INTO Submission ( title, slides, codes )" +
                        "VALUES  ( @Title, @Slides, @Codes );";
    
        using (var con = new SqlConnection(_connStr))
        {
            con.Open();
            using (var cmd = new SqlCommand(query, con))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Title", title);
                cmd.Parameters.AddWithValue("@Slides", slides);
                cmd.Parameters.AddWithValue("@Codes", codes);
                nofRow = cmd.ExecuteNonQuery();
            }
        }
        return nofRow;
    }
