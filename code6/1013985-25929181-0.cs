    public DataTable Show(string selectQuery) {
         DataTable dt = new DataTable();
    
         using (SqlConnection cn = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString)) {
               SqlDataAdapter da = new SqlDataAdapter(selectQuery, cn);
               da.Fill(dt);
          }
          return dt;
    }
