            BackupDatabase(server,port, user,password, dbname, "backupdir", dbname, "C:\\Program Files\\PostgreSQL\\11\\bin\\");
        }
        public static string BackupDatabase(
                    string server,
                    string port,
                    string user,
                    string password,
                    string dbname,
                    string backupdir,
                    string backupFileName,
                    string backupCommandDir)
        {
            try
            {
                Environment.SetEnvironmentVariable("PGPASSWORD", password);
                string backupFile = backupdir + backupFileName + "_"+DateTime.Now.ToString("yyyy") + "_" + DateTime.Now.ToString("MM") + "_" + DateTime.Now.ToString("dd") + ".backup";
              
                string BackupString = " -f \"" + backupFile + "\" -F c"+
                  " -h "  + server + " -U " + user + " -p " + port + " -d " + dbname;
                Process proc = new System.Diagnostics.Process();
                proc.StartInfo.FileName = backupCommandDir + "\\pg_dump.exe";
                proc.StartInfo.Arguments = BackupString;
                proc.StartInfo.RedirectStandardOutput = true;//for error checks BackupString
                proc.StartInfo.RedirectStandardError = true;
                proc.StartInfo.UseShellExecute = false;//use for not opening cmd screen
                proc.StartInfo.CreateNoWindow = true;//use for not opening cmd screen
                proc.Start();
                proc.WaitForExit();
                proc.Close();
                return backupFile;
            }
            catch (Exception ex)
            {
                return null;
            }
