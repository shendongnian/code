    private DataTable GetData()
    {
        DataTable dt = new DataTable();
        using (SqlConnection c = new SqlConnection(ConfigurationManager.ConnectionStrings["MyDB"].ConnectionString))
        {
            c.Open();
            using (SqlCommand cmd = new SqlCommand("spGetData", c))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
            }
        }
        return dt;
    }
