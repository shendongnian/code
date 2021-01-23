      public ServerSettings()
    {
        InitializeComponent();
    }
    private void btTest_Click(object sender, RoutedEventArgs e)
    {
        SQLConnectionClass con = new SQLConnectionClass();
        con.TestConnectivity(tbServer.Text, tbUsername.Text, tbPassword.Text, tbDatabase.Text, this);
    }
}
