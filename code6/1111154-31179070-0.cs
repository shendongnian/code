        public void Conn() {
            string oracleConnectionString = "User Id=" + oracleUser + "; Password=" + oraclePassword + "; Data Source=" + oracleDatabase;
            //using (oracleConnection = new OracleConnection(oracleConnectionString))
            oracleConnection = new OracleConnection(oracleConnectionString);
            try
            {
                oracleConnection.Open();
                Console.WriteLine(oracleConnection.ServerVersion);
                Console.ReadKey();
                OracleGlobalization oracleSession = oracleConnection.GetSessionInfo();
                oracleSession.DateFormat = "dd-mm-yyyy hh24:mi:ss";
                oracleConnection.SetSessionInfo(oracleSession);
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }
