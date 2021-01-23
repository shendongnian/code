    DateTime dob = DateTime.ParseExact(TextBox1.Text, "dd/MM/yyyy", null);
    using (MySqlConnection conn = new MySqlConnection(cnnstring))
    {
        string cmdText = "INSERT INTO trydate(Dob) VALUES (@Dob)";
    
        using (MySqlCommand cmd = new MySqlCommand(cmdText, conn))
        {
            cmd.Parameters.AddWithValue("@Dob", dob);
            conn.Open();
            int a = cmd.ExecuteNonQuery();
            Label1.Text = "Data Saved";
            TextBox1.Text = "";
        }
    }
