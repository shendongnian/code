    namespace answer1
    {
        using System.ComponentModel;
        using System.Data.SqlClient;
    
        internal class ConnectionCheck
        {
            private BackgroundWorker bw = new BackgroundWorker();
    
            private void CheckConnection()
            {
                string connetionString = null;
                SqlConnection cnn;
                connetionString = "Data Source=ServerName;Initial Catalog=DatabaseName;User ID=UserName;Password=Password";
                cnn = new SqlConnection(connetionString);
                try
                {
                    cnn.Open();
                    Console.WriteLine("Connection Open ! ");
                    cnn.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Can not open connection ! ");
                }
            }
    
            private void bw_DoWork(object sender, DoWorkEventArgs e)
            {
                while (true)
                {
                    CheckConnection();
                    System.Threading.Thread.Sleep(5000);
                }
            }
    
            /// <summary>
            /// This is the Main routine you call to execute the background thread
            /// </summary>
            public void RunBackgroundSQLCheck()
            {
                bw.DoWork += this.bw_DoWork;
                bw.RunWorkerAsync();
            }
        }
    }
