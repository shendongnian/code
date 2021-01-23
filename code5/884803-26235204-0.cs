    <pre>
    public static void GetOperaURL()
    {
       Process[] OProcesses = Process.GetProcessesByName("opera");
       string url = null;
       foreach (Process proc in OProcesses)
       {
           if (proc.MainWindowHandle != IntPtr.Zero)
           {
                url = getOperaUrlFromProcess(proc);
                break;
            }
        }
    }
