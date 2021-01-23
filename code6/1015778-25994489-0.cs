    private void dispatcherTimer_Tick(object sender, EventArgs e)
    {
        IntPtr activeWindow = GetForegroundWindow();
        List<String> strListProcesses = new List<string>();
        foreach (Process process in Process.GetProcesses())
        {
            try
            {
                if (activeWindow == process.MainWindowHandle)
                {
                    newApplication = process.MainWindowTitle;
                }
            }
            catch (System.ComponentModel.Win32Exception ex)
            {
                
            }
        }
    }
