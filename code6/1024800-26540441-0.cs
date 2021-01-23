    private void button1_Click(object sender, EventArgs e)
    {
        Process p = Process.GetProcessesByName("PaintDotNet").FirstOrDefault();
        if (p != null)
        {
            IntPtr h = p.MainWindowHandle;
            SetForegroundWindow(h);
            SendKeys.SendWait("^(o)"); //^(o) will sends the Ctrl+O key to the application. 
        }
    }
