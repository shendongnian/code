     private void LogonToReport(string server, string database,
             string ID, string password)
          {
             TableLogOnInfo logonInfo = new TableLogOnInfo();
             foreach(Table table in Report.Database.Tables)
             {
                logonInfo = table.LogOnInfo;
                logonInfo.ConnectionInfo.ServerName = server;
                logonInfo.ConnectionInfo.DatabaseName = database;
                logonInfo.ConnectionInfo.UserID = ID;
                logonInfo.ConnectionInfo.Password = password;
                
                table.ApplyLogOnInfo(logonInfo);
             }
          }
