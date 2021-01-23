     // get current process
            Process current = Process.GetCurrentProcess();
            // get all the processes with currnent process name
            Process[] processes = Process.GetProcessesByName(current.ProcessName);
            foreach (Process process in processes)
            {
                //Ignore the current process  
                if (process.Id != current.Id)
                {
                    process.Kill();
                }
            }
