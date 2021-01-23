        Thread t = new Thread(() => {
            using (SqlConnection con = new SqlConnection()) {
                con.ConnectionString = SomeConnectionString;
                string query = "SELECT FIELD1,FIELD2,FIELD3 from table1";
                    using (SqlCommand com = new SqlCommand(query, con)) {
                        
                        try {
                           con.Open();
                           
                           using (SqlDataReader reader = com.ExecuteReader()) {
                               DataTable dt = new DataTable();
                               dt.Load(reader);
                           }
                        } catch (Exception ex) {
                            throw ex;
                        } finally {
                            con.Close();
                            GC.Collect();
                            GC.WaitForPendingFinalizers();
                            SqlConnection.ClearAllPools();
                        }
                    }
            }
        });
        t.IsBackground = true;
        t.Start();
