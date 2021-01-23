            Process[] processes = System.Diagnostics.Process.GetProcesses();
            if (processes.Any(c => c.ProcessName == "firefox"))
            {
               //your update code
            }
