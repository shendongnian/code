    private void ConnectToServer()
        {
            string sServerName = _fileIO.GetServerInfo("ServerName");
            string sSqlInstance = _fileIO.GetServerInfo("SqlInstance");
            string sDataBase = _fileIO.GetServerInfo("DataBase");
            string sUserID = _fileIO.GetServerInfo("UserID");
            string sPassWord = _fileIO.GetServerInfo("PassWord");
             //"Server=myServerName\myInstanceName;Database=myDataBase;User Id=myUsername;Password=myPassword";
            string sConnectionString = string.Format("Server={0};Database={2};User Id={3};Password={4}",
                                                    sServerName,sSqlInstance,sDataBase,sUserID,sPassWord);
            
            try
            {
                _cnn = new SqlConnection(sConnectionString); 
                _cnn.Open();
                if (_cnn.State.ToString() != "Open")
                {
                    MessageBox.Show("Application could not connect to server ","Connection Failed ",MessageBoxButton.OK,MessageBoxImage.Error);
                }
                _cnn.Close();
            }
            catch (Exception _ex)
            {
                MessageBox.Show(_ex.ToString());
            }
        }
