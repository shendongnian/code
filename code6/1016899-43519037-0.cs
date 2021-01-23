        Process[] processes = Process.GetProcesses();
        foreach (Process p in processes)
        {
            if (p.ProcessName.ToLower().Contains("werfault"))
            {
                // Get the CommandLine string from the werfault.exe
                string startupParam = GetCommandLine(p);
                
                // Get the ProcessID of the frozen Process.
                // Sure you can optimize this part, but it works in this case :)
                int pID = int.Parse(startupParam.Split(new string[] { "-p" }, StringSplitOptions.None).
                          Last().Split(new string[] { "-s" }, StringSplitOptions.None).First().Trim());
                
                // Get the frozen Process.
                Process frozenProcess = Process.GetProcessById(pID);
            }
        }
        /// <summary>
        /// Returns the CommandLine from a Process.
        /// </summary>
        /// <param name="process"></param>
        /// <returns></returns>
        private static string GetCommandLine(Process pProcess)
        {
            // Create a new CommandLine with the FileName of the given Process.
            var commandLine = new StringBuilder(pProcess.MainModule.FileName);
            commandLine.Append(" ");
            // Now we need to query the CommandLine of the process with ManagementObjectSearcher.
            using (var searcher = new ManagementObjectSearcher("SELECT CommandLine FROM Win32_Process WHERE ProcessId = " + pProcess.Id))
            {
                // Append the arguments to the CommandLine.
                foreach (var @object in searcher.Get())
                {
                    commandLine.Append(@object["CommandLine"]);
                    commandLine.Append(" ");
                }
            }
            // Return the CommandLine.
            return commandLine.ToString();
        }
