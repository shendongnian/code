    class SQLConnectionClass
    {
        ServerSettings  _serverSettings, 
        public void TestConnectivity(String server, String user, String pass, String db, ServerSettings serverSettings )
        {
           _serverSettings = serverSettings;
            string ConnectionString = @"Data Source=" + server +
                           ";Initial Catalog=" + db +
                           ";User ID=" + user +
                           ";Password=" + pass;
            SqlConnection Connection = new SqlConnection(ConnectionString);
            try
            {
                Connection.Open();
                Connection.Close();
                success();
            }
            catch (Exception ex)
            {
               failed(ex.Message.ToString());
            }
        }
    
        void success()
        {
            MessageBox.Show("Success function","Message");
            Content.ServerSettings mine = new Content.ServerSettings();
            _serverSettings.lbConnectionStatus.Background = Brushes.Green;
        }
    
        void failed(string msg)
        {
            MessageBox.Show(msg,"Message");
            Content.ServerSettings mine = new Content.ServerSettings();
            _serverSettings.lbConnectionStatus.Background = Brushes.Red;
    
        }
    }
