        public static void TryWebBrowser()
        {
            bool _jsLoaded = false;
            string _directory = AppDomain.CurrentDomain.BaseDirectory;
            System.Diagnostics.ProcessStartInfo _sinfo = new    
            System.Diagnostics.ProcessStartInfo(_directory + "loginFile.html");
            System.Diagnostics.Process.Start(_sinfo);
            while (_jsLoaded == false) 
            {
                System.Diagnostics.Process[] _runningProcesses = 
                System.Diagnostics.Process.GetProcesses();
                foreach (System.Diagnostics.Process _p in _runningProcesses)
                {
                    if (_p.MainWindowTitle.Contains("Jaspersoft"))
                    {
                        _jsLoaded = true;
                        break;
                    }
                }
            }
            
        }
