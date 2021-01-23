    public class Create_Connection
        {
            public static readonly string CONN_STRING = ConfigurationManager.ConnectionStrings["TaskConnectionString"].ConnectionString;
            public static readonly SqlConnection SqlConn = new SqlConnection(CONN_STRING);
    
            public DataSet ExecuteSql(string sql)
            {
                var ds = new DataSet();
                using (var CONN = new SqlConnection(CONN_STRING)) {
                    CONN.Open();
                    var da = new SqlDataAdapter(sql, CONN_STRING);
                    da.Fill(ds);
                    CONN.Close();
                }
                return ds;
            }
        }
