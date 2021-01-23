    using(SqlConnection conn = new SqlConnection(SqlCon.DBCON))
    using(SqlCommand sc = new SqlCommand(@"select ApplicationId, Application_Name 
                                           from Application", conn))
    {
         conn.Open();
         using(SqlDataReader reader = sc.ExecuteReader())
         {
              DataTable dt = new DataTable();
              dt.Load(reader);
              .....
    
