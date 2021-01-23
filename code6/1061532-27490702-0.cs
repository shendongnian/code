    con.Open();
    String query = "INSERT INTO user (Username, [Password]) values(@Username, @Password)";
    OleDbCommand cmd = new OleDbCommand(query, con);
    cmd.Parameters.AddWithValue("@Username",textBox1.Text);
    cmd.Parameters.AddWithValue("@Password", textBox2.Text);
    cmd.ExecuteNonQuery();
    con.Close();
    MessageBox.Show("User Account Created");
    this.Close();
