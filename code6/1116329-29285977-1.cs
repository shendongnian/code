    Process[] AllProcess = Process.GetProcesses();
                foreach (var process in AllProcess)
                {
                    if (process.MainWindowTitle != "")
                    {
                        string s = process.ProcessName.ToLower();
                        if (s == "chrome" )
                            process.Kill();
                    }
                }
