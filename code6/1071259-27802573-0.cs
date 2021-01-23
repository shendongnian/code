    public DataTable GetData()
    {
         SqlConnection conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["BarManConnectionString"].ConnectionString);
         conn.Open();
         string query = "SELECT count(*) from fruit where status = 2";
         SqlCommand cmd = new SqlCommand(query, conn);
         DataTable dt = new DataTable();
         dt.Load(cmd.ExecuteReader());
         return dt;
    }
