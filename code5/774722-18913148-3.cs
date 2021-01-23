    private void button1_Click(object sender, EventArgs e)
            {
                    con.Open();
                    SqlCommand com = new SqlCommand("select * from yourtable", con);
                    SqlDataAdapter adp = new SqlDataAdapter(com);
                    DataTable dt = new DataTable();
                    adp.Fill(dt);
                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns.Add("manualcolumn", "manualcolumn");
            }
