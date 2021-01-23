     public static string GetMainModuleFilepath(int processId)
        {
            string wmiQueryString = "SELECT * FROM Win32_Process WHERE ProcessId = " + processId;
            using (var searcher = new ManagementObjectSearcher(wmiQueryString))
            {
                using (var results = searcher.Get())
                {
                    ManagementObject mo = results.Cast<ManagementObject>().FirstOrDefault();
                    if (mo != null)
                    {
                        return (string)mo["CommandLine"];
                    }
                }
            }
            Process testProcess = Process.GetProcessById(processId);
            return null;
        }
