    private void login_Click(object sender, RoutedEventArgs e)
    {
        var connectionString = ConnectionStrings.GetConnectionString(username.Text, password.Password);
        MessageBox.Show(connectionString);
    }
