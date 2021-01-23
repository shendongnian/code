    private void button1_Click(object sender, EventArgs e)
    {
        string connectionString = @"Data Source=" + System.IO.File.ReadAllText("Server.ini") + ";" +
                                  "Initial Catalog=" + "lin2world" + ";" + "User ID=" +
                                  System.IO.File.ReadAllText("User.ini") + ";" + "Password=" +
                                  System.IO.File.ReadAllText("Password.ini");
        string sql = string.Format("UPDATE user_item SET amount='{0}' WHERE char_id='{1}' AND item_type='{2}'",
                                   textBox3.Text, textBox1.Text, textBox2.Text);
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlCommand command = new SqlCommand(sql, connection);
            command.Connection.Open();
            command.ExecuteNonQuery();
        }
        MessageBox.Show("Item Amount Changed");
    }
