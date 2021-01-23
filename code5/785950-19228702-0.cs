    public static bool IsProgramRunning(string TitleOfYourForm)
    {
        bool result = false;
        Process[] processes = Process.GetProcesses();
        foreach (Process p in processes)
        {
             if (p.MainWindowTitle.Contains(TitleOfYourForm))
             {
                 result = true;
                 break;
             }
        }
        return result;
    }
