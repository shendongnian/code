        int IdRemoto = int.Parse(textBoxID.Text);
        Process[] processlist = Process.GetProcessesByName("AA_v3.3");
        foreach (Process process in processlist)
        {
            if (!String.IsNullOrEmpty(process.MainWindowTitle))
            {
                if (IdRemoto.ToString() == process.MainWindowTitle)
                {
                    ShowWindow(process.MainWindowHandle, 9);
                    SetForegroundWindow(process.MainWindowHandle);  
                }
            }
        }
       [DllImport("user32.dll")]
       private static extern bool SetForegroundWindow(IntPtr hWnd);
       [DllImport("user32.dll")]
       private static extern bool ShowWindow(IntPtr hWind, int nCmdShow);
