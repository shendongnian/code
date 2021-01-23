      public string RequestInfo(string remoteHost, string userName, string password, string[] lstCommands) {
            m_szFeedback = "Feedback from: " + remoteHost + "\r\n";
            ProcessStartInfo psi = new ProcessStartInfo()
            {
                FileName = PLINK_PATH, // A const or a readonly string that points to the plink executable
                Arguments = String.Format("-ssh {0}@{1} -pw {2}", userName, remoteHost, password),
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                RedirectStandardInput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };
            Process p = Process.Start(psi);
            
            m_objLock = new Object();
            m_blnDoRead = true;
            
            AsyncReadFeedback(p.StandardOutput); // start the async read of stdout
            AsyncReadFeedback(p.StandardError); // start the async read of stderr
            StreamWriter strw = p.StandardInput;
            foreach (string cmd in lstCommands)
            {
                strw.WriteLine(cmd); // send commands 
            }
            strw.WriteLine("exit"); // send exit command at the end
            p.WaitForExit(); // block thread until remote operations are done
            return m_szFeedback;
        }
        private String m_szFeedback; // hold feedback data
        private Object m_objLock; // lock object
        private Boolean m_blnDoRead; // boolean value keeping up the read (may be used to interrupt the reading process)
        public void AsyncReadFeedback(StreamReader strr)
        {
            Thread trdr = new Thread(new ParameterizedThreadStart(__ctReadFeedback));
            trdr.Start(strr);
        }
        private void __ctReadFeedback(Object objStreamReader)
        {
            StreamReader strr = (StreamReader)objStreamReader; 
            string line;          
            while (!strr.EndOfStream && m_blnDoRead) 
            {
                line = strr.ReadLine();
                // lock the feedback buffer (since we don't want some messy stdout/err mix string in the end)
                lock (m_objLock) { m_szFeedback += line + "\r\n"; }
            }
        }
