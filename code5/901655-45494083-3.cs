        Thread t = new Thread(() => {
            using (SqlConnection con = new SqlConnection(_someConnectionString)) {
                string query = "SELECT FIELD1, FIELD2, FIELD3 FROM table1";
                    using (SqlCommand com = new SqlCommand(query, con)) {
                        
                        try {
                           con.Open();
                           
                           using (SqlDataReader reader = com.ExecuteReader()) {
                               if (reader.HasRows) {
                                   DataTable dt = new DataTable();
                                   dt.Load(reader);
                               }
                           }
                        } catch (Exception ex) {
                            // Anything you want to do with ex
                        } finally {
                            con.Close();
                        }
                    }
            }
        });
        t.IsBackground = true;
        t.Start();
