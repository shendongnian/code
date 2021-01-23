     private DataSet GetData(string query)
    {
        string conString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        SqlCommand cmd = new SqlCommand(query);
        using (SqlConnection con = new SqlConnection(conString))
        {
            using (SqlDataAdapter da = new SqlDataAdapter())
            {
                cmd.Connection = con;
                da.SelectCommand = cmd;
                using (DataSet ds = new DataSet())
                {
                    da.Fill(ds);
                    return ds;
                }
            }
        }
    }
