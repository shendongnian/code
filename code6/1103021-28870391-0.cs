     public class Connection
    {
     conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationServices"].ConnectionString);
    public SqlDataAdapter ad;
    public DataTable gettable(string cmdtxt)
    {
        DataTable dt = new DataTable();
        if (conn.State == ConnectionState.Open)
        {
            conn.Close();
        }
        conn.Open();
        dt.Clear();
        ad = new SqlDataAdapter(cmdtxt, conn);
        ad.Fill(dt);
        return dt;
    }
    }
