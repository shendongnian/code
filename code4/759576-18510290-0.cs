    [DllImport("user32.dll")]
    static extern bool SetForegroundWindow(IntPtr hWnd);
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        var currentProcess = Process.GetCurrentProcess();
        foreach (Process p in Process.GetProcessesByName(currentProcess.ProcessName))
        {
            if (p.Id != currentProcess.Id)
            {
                MessageBox.Show("Already running");
                SetForegroundWindow(p.MainWindowHandle);
                return;
            }
        }
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.Run(new Form1());
    }
