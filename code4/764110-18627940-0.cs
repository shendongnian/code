    private void button3_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=" + textBox4.Text + ";" + "Initial Catalog=" + textBox1.Text + ";" + "User ID=" + textBox2.Text + ";" + "Password=" + textBox3.Text;
            string sql = "SELECT account FROM user_account";
            SqlConnection connection = new SqlConnection(connectionString) ;
            SqlDataAdapter dataadapter = new SqlDataAdapter(sql, connection);
            DataSet ds = new DataSet();
            connection.Open();
            dataadapter.Fill(ds, "account");
            connection.Close();
            dataGridView1.DataSource = ds;
            dataGridView1.Databind();    
        }
