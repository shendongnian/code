    private static string GetConnectionString()
    {
        return ConfigurationManager.ConnectionStrings["StackOverflow"].ConnectionString;
    }
    public static string CleanSQL(string data)
    {
        return data.Replace("'", "''");
    }
    public static int ExecuteNonQuery(string SQL)
    {
        using (SqlConnection conn = new SqlConnection(GetConnectionString()))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(SQL, conn);
            int result = cmd.ExecuteNonQuery();
            
            conn.Close();
            return result;
        }
    }
    public static object ExecuteScalar(string SQL)
    {
        using (SqlConnection conn = new SqlConnection(GetConnectionString()))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(SQL, conn);
            object result = cmd.ExecuteScalar();
            conn.Close();
            return result;
        }
    }
    public class SqlCommandEx : IDisposable
    {
        private SqlConnection conn;
        public SqlCommand CommandObject;
        //public static System.Collections.Stack inuse = new System.Collections.Stack();
        public SqlCommandEx(string SQL)
        {
            conn = new SqlConnection(GetConnectionString());
            conn.Open();
            CommandObject = new SqlCommand(SQL, conn);
            //inuse.Push(DateTime.Now);
        }
        public DataTable GetDataTable()
        {
            SqlDataAdapter da = new SqlDataAdapter(CommandObject);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public void AddWithValue(string parameter, object value)
        {
            CommandObject.Parameters.AddWithValue(parameter, value);
        }
        public void Dispose()
        {
            //inuse.Pop();
            conn.Close();
        }
    }
    public static DataTable GetDataTable(string SQL)
    {
        using (SqlConnection conn = new SqlConnection(GetConnectionString()))
        {
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(SQL, conn);
            DataTable result = new DataTable();
            da.Fill(result);
            conn.Close();
            return result;
        }
    }
