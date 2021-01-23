    DataTable dt = new DataTable();
    using (SqlConnection connection = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString))
    {
        using (SqlCommand cmd = new SqlCommand("SELECT something FROM table"))
        {
            cmd.CommandType = CommandType.Text;
            cmd.Connection = connection;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
        }
    }
