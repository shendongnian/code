            using System.Data;
            using System.Data.SqlClient;
            int callLogId = 0;
            DateTime startDate = DateTime.Now;
            DateTime endDate = DateTime.Now;
            string logCode = "";
            string connectionString = "YourConnectionString";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("T_FILTER", connection);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("Call_LogID",callLogId);
                cmd.Parameters.AddWithValue("StarDate",startDate);
                cmd.Parameters.AddWithValue("EndDate",endDate);
                cmd.Parameters.AddWithValue("Log_code",logCode);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                  //do something
                }
                dr.Dispose();
                cmd.Dispose();
            }
