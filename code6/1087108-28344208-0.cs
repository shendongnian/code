            Process currentProcess = Process.GetCurrentProcess();
            Process[] localAll = Process.GetProcesses();
            foreach (Process p in localAll)
            {
                if (p.MainModule != null)
                {
                    int processId = p.Id;
                    string name = p.MainModule.ModuleName;
                    string filename = p.MainModule.FileName;
                }
            }
