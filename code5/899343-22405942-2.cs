    private void buttonLogin_Click(object sender, RoutedEventArgs e)
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Denis\Documents\Data.mdf;Integrated Security=True;Connect Timeout=30");
        SqlCommand cmd = new SqlCommand("Select * from Login where Username='@Name' and Password='@Pass'", conn);
        cmd.Parameters.Add(new SqlParameter("Name", textBoxUsername);
        cmd.Parameters.Add(new SqlParameter("Pass", textBoxPassowrd);
        conn.Open();
        SqlDataReader rdr= cmd.ExecuteReader();
        string username = null; 
        if (rdr.HasRows)
        {
            while(rdr.Read())
            {
               username = rdr["Username"].ToString();
            }
            conn.Close();
            this.Hide();
            MainWindow mn = new MainWindow(); 
            mn.Show();
            this.Close();
        }
        else
        {
            MessageBox.Show("Invalid username or password!", "Paznja", MessageBoxButton.OK, MessageBoxImage.Error);
            conn.Close();
        }
    }
