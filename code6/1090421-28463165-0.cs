    ////
            // 'WindowsIdentity' Extension Method Demo: 
            //   Enumerate all running processes with their associated Windows Identity
            ////
 
            foreach (var p in Process.GetProcesses())
            {
                string processName;
 
                try
                {
                    processName = p.WindowsIdentity().Name;
 
                }
                catch (Exception ex)
                {
 
                    processName = ex.Message; // Probably "Access is denied"
                }
 
                Console.WriteLine(p.ProcessName + " (" + processName + ")");
            }
