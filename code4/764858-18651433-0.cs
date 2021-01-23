        private void button1_Click(object sender, EventArgs e)
    {
        string connectionString = @"Data Source=" + System.IO.File.ReadAllText("Server.ini") + ";" + "Initial Catalog=" + "lin2world" + ";" + "User ID=" + System.IO.File.ReadAllText("User.ini") + ";" + "Password=" + System.IO.File.ReadAllText("Password.ini");
        string sql = "UPDATE user_item SET amount='" + textBox3.Text + "' WHERE char_id='" + textBox1.Text + "' AND item_type='" + textBox2.Text + "' ";
        SqlConnection connection = new SqlConnection(connectionString);
        SqlDataAdapter dataadapter = new SqlDataAdapter(sql, connection);
        DataSet ds = new DataSet();
        connection.Open();
        dataadapter.Fill(ds, "user_item");
        connection.Close();
        MessageBox.Show("Item Amount Changed");
    }
