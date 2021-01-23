    class SQLConnectionClass
        {
     
        public bool TestConnectivity(String server, String user, String pass, String db,  )
        {
           _serverSettings = serverSettings;
            string ConnectionString = @"Data Source=" + server +
                           ";Initial Catalog=" + db +
                           ";User ID=" + user +
                           ";Password=" + pass;
            SqlConnection Connection = new SqlConnection(ConnectionString);
            
             Connection.Open();
             Connection.Close();
             return true;
        }      
      
    }
    public partial class ServerSettings : UserControl
      {
          public ServerSettings()
        {
            InitializeComponent();
        }
        private void btTest_Click(object sender, RoutedEventArgs e)
        {
    
    try{
            SQLConnectionClass con = new SQLConnectionClass();
            con.TestConnectivity(tbServer.Text, tbUsername.Text, tbPassword.Text, tbDatabase.Text);
             MessageBox.Show("Success function","Message");
             lbConnectionStatus.Background = Brushes.Green;
    
    }
    catch(Exception ex)       
    {
       MessageBox.Show(ex.Message.ToString(),"Message");
       lbConnectionStatus.Background = Brushes.Red;
    }
     }
    }
