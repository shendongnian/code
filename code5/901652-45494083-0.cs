        Thread t = new Thread(() => {
            using (SqlConnection con = new SqlConnection()) {
                con.ConnectionString = valid_connection_string;
                string query = "UPDATE tblName SET FIELD2=@f2val WHERE FIELD1=@f1val;";
                    using (SqlCommand com = new SqlCommand(query, con)) {
                        com.Parameters.AddWithValue("f1val", some_key);
                        com.Parameters.AddWithValue("f2val", some_newval);
                        
                        try {
                           con.Open();
                           var result = com.ExecuteNonQuery();
                           // Make use of result if you need validation
                        } catch (Exception ex) {
                            throw ex;
                        } finally {
                            con.Close();
                            GC.Colect();
                            GC.WaitForPendingFinalizers();
                            SqlConnection.ClearAllPools();
                        }
                    }
            }
        });
        t.IsBackground = true;
        t.Start();
