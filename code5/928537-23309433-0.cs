    private DataTable GetResultReport()
        {
            DataTable retVal = new DataTable();
            EntityConnection entityConn = (EntityConnection)db.Connection;
            SqlConnection sqlConn = (SqlConnection)entityConn.StoreConnection;
            using (SqlCommand cmdReport = sqlConn.CreateCommand())
            {
                cmdReport.CommandType = CommandType.StoredProcedure;
                cmdReport.CommandText = "proc_GetData";
                SqlDataAdapter daReport = new SqlDataAdapter(cmdReport);
                using (cmdReport)
                {
                    daReport.Fill(retVal);
                }
            }
            return retVal;
        }
