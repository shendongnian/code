    if (user_txt.Text != "" & pass_txt.Text != "")
    {
        string queryText = "SELECT Count(*) FROM stiguidancesample.users " +  "WHERE       username = @Username AND password = @Password COLLATE SQL_Latin1_General_CP1_CS_AS ";
    MySqlConnection cn = new MySqlConnection(MyConnectionString);
    MySqlCommand cmd = new MySqlCommand(queryText, cn);
      {
        cn.Open();
        cmd.Parameters.AddWithValue("@Username", user_txt.Text);  // cmd is SqlCommand 
        cmd.Parameters.AddWithValue("@Password", pass_txt.Text);
        int result = Convert.ToInt32(cmd.ExecuteScalar());
        if (result > 0)
            MessageBox.Show("Loggen In!");
        else
            MessageBox.Show("User Not Found!");
      }
    }
