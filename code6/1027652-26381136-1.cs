    private const int SW_SHOWMINIMIZED = 2;
    
    [DllImport("user32.dll")]
    private static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);
    
    Process proc;
    foreach (Process process in Process.GetProcesses())
    {
        if (process.ProcessName.Equals("firefox"))
            proc = process;
    }
    
    IntPtr hWnd = proc.MainWindowHandle;
    if (!hWnd.Equals(IntPtr.Zero))
    {
        ShowWindowAsync(hWnd, SW_SHOWMINIMIZED);
    }
