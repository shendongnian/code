            private void button3_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=" + textBox4.Text + ";" + "Initial Catalog=" + "lin2db" + ";" + "User ID=" + textBox2.Text + ";" + "Password=" + textBox3.Text;
            string sql = "SELECT account ,pay_stat FROM user_account where account='" + textBox7.Text + "' ";          
            SqlConnection connection = new SqlConnection(connectionString) ;
            SqlDataAdapter dataadapter = new SqlDataAdapter(sql, connection);
            DataSet ds = new DataSet();
            connection.Open();
            dataadapter.Fill(ds, "pay_stat");
            connection.Close();
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "pay_stat";
            
      
        }
