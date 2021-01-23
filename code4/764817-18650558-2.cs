            // Gets the processes with given name
            // If one or more instances are running
            foreach (Process exe in Process.GetProcesses())
            {
                if (exe.ProcessName.Contains("WINWORD"))
                {
                    exe.Exited += exe_Exited;
                    selectedProcesses.Add(exe);
                }
            }
