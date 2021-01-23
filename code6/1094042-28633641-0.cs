    static void Main(string[] args){        
        const string logSource = "Microsoft-Windows-PrintService/Operational";
        
        /* store print jobs */
        
        ClearLog(logSource);
    }
    public static void ClearLog(string logName)
        {            
            var psi = new ProcessStartInfo(
                "wevtutil.exe",
                String.Format("cl {0}", logName));
            psi.Verb = "runas"; // Run as administrator
            using (var p = new Process())
            {
                p.StartInfo = psi;                
                p.Start();              
            }
        }
