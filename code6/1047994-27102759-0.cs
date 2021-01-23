            try
            {
                dt = new DataTable();
                using (MySqlConnection conn = new MySqlConnection("datasource=localhost;port=3306;username=root;password=password"))
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = "SELECT * FROM `tablename`.`expeditori`";
                        MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                        da.Fill(dt);
                    }
                    conn.Close();
                }
              
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
