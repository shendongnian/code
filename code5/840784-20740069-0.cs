    Process[] processlist = Process.GetProcesses();
    foreach (Process theprocess in processlist)
    {
        label1.Text += theprocess.MainModule.FileVersionInfo.FileDescription + "\n";
    }
