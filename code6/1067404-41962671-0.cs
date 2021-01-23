            string StrQuery;
            try
            {
                string MyConnection2 = "server=localhost;user id=root;password=;database=k";
                using (MySqlConnection conn = new MySqlConnection(MyConnection2))
                {
                    using (MySqlCommand comm = new MySqlCommand())
                    {
                        comm.Connection = conn;
                        conn.Open();
                        for (int i = 0; i < dataGridView3.Rows.Count; i++)
                        {
                            StrQuery = @"update s set  Quantity='" + dataGridView3.Rows[i].Cells["Quantity"].Value.ToString() + "' where No='" + dataGridView3.Rows[i].Cells["Item No"].Value.ToString() + "';";
                            comm.CommandText = StrQuery;
                            comm.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch
            { 
            }
        }
