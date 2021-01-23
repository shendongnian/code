        public static bool IsFileClosed(string filepath, bool wait)
        {
            bool        fileClosed = false;
            int         retries = 20;
            const int   delay = 500; // Max time spent here = retries*delay milliseconds
            if (!File.Exists(filepath))
                return false;
            do
            {
                try 
                {
                    // Attempts to open then close the file in RW mode, denying other users to place any locks.
                    FileStream fs = File.Open(filepath, FileMode.Open, FileAccess.ReadWrite, FileShare.None);
                    fs.Close();
                    fileClosed = true; // success
                }
                catch (IOException) {}
                if (!wait) break;
                retries --;
                if (!fileClosed)
                    Thread.Sleep( delay );
            }
            while (!fileClosed && retries > 0);
            return fileClosed;
        }
