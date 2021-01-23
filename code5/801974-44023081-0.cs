    public static void Attach(DTE2 dte)
            {
                var processes = dte.Debugger.LocalProcesses;
                foreach (var proc in processes.Cast<EnvDTE.Process>().Where(proc => proc.Name.IndexOf("YourProcess.exe") != -1))
                    proc.Attach();
            }
    
            internal static DTE2 GetCurrent()
            {
                var dte2 = (DTE2)Marshal.GetActiveObject("VisualStudio.DTE.12.0"); // For VisualStudio 2013
    
                return dte2;
            }
