    private void OpenBrowser()
    {
        bool processStarted = false;
        Process[] processes = Process.GetProcesses();
        foreach (var item in processes)
        {
            if (item.MainWindowTitle.Equals("Google - Google Chrome", StringComparison.OrdinalIgnoreCase))
            {
                processStarted = true;
                break;
            }
        }
        if (!processStarted)
        {
            Process p = new Process();
            ProcessStartInfo info = new ProcessStartInfo();
            info.FileName = "chrome.exe";
            p.StartInfo = info;
            info.Arguments = "https://www.google.lk";
            p.Start();
        }
    }
