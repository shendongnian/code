        private static string GetLogTexts(Liststring> logfilenames)
        {
            List<string> _logtexts = new List<string>();
            string _basedir = GetBaseDir();
            foreach(string logfilename in logfilenames)
            {
            	Process proc = new Process();
            	proc.StartInfo.FileName = _basedir + "\\bin\\mysqlbinlog";
            	proc.StartInfo.Arguments = string.Format("\"{0}\"", logfile);
            	proc.StartInfo.UseShellExecute = false;
            	proc.StartInfo.RedirectStandardInput = proc.StartInfo.RedirectStandardOutput = true;
            	proc.Start();
            	_logtexts.Add(proc.StandardOutput.ReadToEnd());
            }
            return _logtexts;
        }
        private static string GetBaseDir()
        {
            string path = "";
            using (MySqlConnection conn = new MySqlConnection(RemoteServerConnectionString))
            {
                conn.Open();
                using (MySqlCommand cmd1 = new MySqlCommand("show global variables like 'basedir'", conn))
                {
                    using (MySqlDataReader reader = cmd1.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            path = reader.GetString(1);
                        }
                    }
                }
            }
            return path;
        }
