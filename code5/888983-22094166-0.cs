    private DataTable getCommand(string stringSQL)
    {
        DataTable dt = new DataTable();
        using (SqlCommand cmd = new SqlCommand(stringSQL, cs))
        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
        {
            da.Fill(dt);
        }
        return dt;
    }
