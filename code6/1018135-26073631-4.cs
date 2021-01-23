    private DataTable GetData(string query, SqlParameter[] prms = null)
    {
        DataTable dt = new DataTable();
        string constr = ConfigurationManager.ConnectionStrings["demoConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            using (SqlCommand cmd = new SqlCommand(query))
            {
                if(prms != null)
                    cmd.Parameters.AddRange(prms);
                using (SqlDataAdapter sda = new SqlDataAdapter())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    sda.Fill(dt);
                }
            }
            return dt;
        }
    }
