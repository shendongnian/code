    public static void sqlExecuteSp(string cmdText, DataTable parDt)
    {
        using (SqlConnection conn = new SqlConnection())
        {
            using (SqlCommand comm = new SqlCommand())                    
            {
                conn.ConnectionString = ConfigurationManager.ConnectionStrings["FTBLConnectionStringSuperUser"].ConnectionString;
                conn.Open();
                using (SqlTransaction trans = conn.BeginTransaction())
                {
                    comm.Connection = conn;
                    comm.CommandType = CommandType.StoredProcedure;
                    comm.Transaction = trans;
                    SqlParameter param = comm.Parameters.AddWithValue("@dt", parDt);
                    param.SqlDbType = SqlDbType.Structured;
                    comm.ExecuteNonQuery();
                    trans.Commit();
                }
            }
            conn.Close();
        }
         
    }
