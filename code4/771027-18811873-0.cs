    public void ReadDataBaseIstoric(DataGridView dataGridView1, string dataBaseName)
    {
        dataGridView1.Rows.Clear();
        using(SqlConnection conn = new SqlConnection("Server=.\\sqlexpress;Trusted_Connection=true;database=" + dataBaseName + ";"))
        using(SqlCommand  cmd = new SqlCommand("select * from istoric", conn))
        {
            SqlDataReader reader = null;
            try
            {
                conn.Open();
                using(SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string[] str = new string[5] { reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString() };
                        dataGridView1.Rows.Add(str);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
