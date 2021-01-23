      private static void AddLog(string strMsg)
        {
            #region logfolder creation
            if (!System.IO.Directory.Exists("C:\\appname"))
            {
                System.IO.Directory.CreateDirectory("C:\\appname");
                if (!System.IO.Directory.Exists("C:\\appname\\Logs"))
                {
                    System.IO.Directory.CreateDirectory("C:\\appname\\Logs");
                }
            }
            #endregion
            #region logfile creation
            FileStream fsc;
            logFileName = "C:\\appname\\Logs\\appnameLog_" + DateTime.Now.Year + DateTime.Now.Month + DateTime.Now.Day + ".txt";
            if (!System.IO.File.Exists(logFileName))
            {
                fsc = new FileStream(logFileName, FileMode.Create, FileAccess.Write);
                fsc.Close();
            }
            #endregion
            #region logging
            using (FileStream fs = new FileStream(logFileName, FileMode.Append, FileAccess.Write))
            {
                using (StreamWriter sr = new StreamWriter(fs))
                {
                    try
                    {
                        sr.WriteLine(strMsg);
                    }
                    catch (Exception exc)
                    {
                        EventLogEntry(exc.ToString().Trim(), EventLogEntryType.Error, 7700);
                    }
                }
            }
            #endregion
        }
