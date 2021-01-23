    private void buttonLogin_Click(object sender, RoutedEventArgs e)
    {
        SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\v11.0;AttachDbFilename=C:\Users\Denis\Documents\Data.mdf;Integrated Security=True;Connect Timeout=30");
        conn.Open();
        SqlCommand cmd = new SqlCommand("Select * from Login where Username='" + textBoxUsername + "' and Password='" + textBoxPassowrd + "'", conn);
        cmd.CommandType = CommandType.Text;
        SqlDataAdapter adapter = new SqlDataAdapter();
        adapter.SelectCommand = cmd;
        DataSet dataSet = new DataSet();
        adapter.Fill(dataSet);
        if (dataSet.Tables[0].Rows.Count>0)
        {
            string username = dataSet.Tables[0].Rows[0]["Username"].ToString();
            Close();
            this.Hide();
            MainWindow mn = new MainWindow(); 
            mn.Show();
            this.Close();
        }
        else
        {
            MessageBox.Show("Invalid username or password!", "Paznja", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
