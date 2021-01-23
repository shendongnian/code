     private void button1_Click(object sender, EventArgs e)
            {
                    con.Open();
                    SqlCommand com = new SqlCommand("select * from yourtable", con);
                    SqlDataAdapter adp = new SqlDataAdapter(com);
                    DataSet ds = new DataSet();
                    adp.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                    dataGridView1.Columns.Add("manualcolumn", "manualcolumn");
            }
