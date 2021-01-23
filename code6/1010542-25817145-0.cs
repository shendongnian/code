    public class SqlManager
    {
        public static string ConnectionString
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["DevConnString"].ConnectionString;
            }
        }
        public static SqlConnection GetSqlConnection()
        {
            return GetSqlConnection(null);
        }
        public static SqlConnection GetSqlConnection(SqlCommand cmd)
        {
            if (cmd.Connection == null)
            {
                SqlConnection conn = new SqlConnection(ConnectionString);
                conn.Open();
                cmd.Connection = conn;
                return conn;
            }
            return cmd.Connection; 
        }
        public static int ExecuteNonQuery(SqlCommand cmd)
        {
            SqlConnection conn = GetSqlConnection(cmd);
            try
            {
                return cmd.ExecuteNonQuery();
            }
            catch
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }
        public static object ExecuteScalar(SqlCommand cmd)
        {
            SqlConnection conn = GetSqlConnection(cmd);
            try
            {
                return cmd.ExecuteScalar();
            }
            catch
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }
        public static DataSet GetDataSet(SqlCommand cmd)
        {
            return GetDataSet(cmd, "Table");
        }
        public static DataSet GetDataSet(SqlCommand cmd, string defaultTable)
        {
            SqlConnection conn = GetSqlConnection(cmd);
            try
            {
                DataSet resultDst = new DataSet();
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    adapter.Fill(resultDst, defaultTable);
                }
                return resultDst;
            }
            catch
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }
        public static DataRow GetDataRow(SqlCommand cmd)
        {
            return GetDataRow(cmd, "Table");
        }
        public static DataRow GetDataRow(SqlCommand cmd, string defaultTable)
        {
            SqlConnection conn = GetSqlConnection(cmd);
            try
            {
                DataSet resultDst = new DataSet();
                using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                {
                    adapter.Fill(resultDst, defaultTable);
                }
                if (resultDst.Tables.Count > 0 && resultDst.Tables[0].Rows.Count > 0)
                {
                    return resultDst.Tables[0].Rows[0];
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
        }
    }
