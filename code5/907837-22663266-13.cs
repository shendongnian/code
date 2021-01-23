    public static DataTable GetG1(int? id=null)
    {
        DataTable dt = new DataTable();
        string strcon = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(strcon))
        {
            conn.Open();
            if(id.HasValue)
            {
                string strQuery = "Select * From ManLog Where Id=@id";
                SqlCommand cmd = new SqlCommand(strQuery, conn);
                cmd.Parameter.Add(new SqlParameter("id",id.Value);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            else
            {
                string strQuery = "Select * From ManLog";
                SqlCommand cmd = new SqlCommand(strQuery, conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
        }
        return dt;
    }
