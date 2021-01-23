     public class Create_Connection
        {
           public static readonly string CONN_STRING = ConfigurationManager.ConnectionStrings["TaskConnectionString"].ConnectionString;
           public static readonly SqlConnection SqlConn = new SqlConnection(CONN_STRING);
         //public static readonly SqlConnection CONN = new SqlConnection(CONN_STRING);
    
            public DataSet ExecuteSql(string sql)
            {
                SqlDataAdapter da;
                DataSet ds;
    
                using (var CONN = new SqlConnection(CONN_STRING)) {
    
                    //if (CONN.State == ConnectionState.Open)
                    //    CONN.Close();
                    CONN.Open();
                    da = new SqlDataAdapter(sql, CONN_STRING);
                    ds = new DataSet();
                    da.Fill(ds);
                    //CONN.Dispose();
                    CONN.Close();
                }
                return ds;
            }
        }
