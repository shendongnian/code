    [DllImport("user32.dll", EntryPoint = "FindWindow")]
    private static extern IntPtr FindWindow(string lp1, string lp2);
    [DllImport("user32.dll", ExactSpelling = true, CharSet = CharSet.Auto)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool SetForegroundWindow(IntPtr hWnd);
    [DllImport("user32.dll", SetLastError = true)]
    public static  extern IntPtr FindWindowEx(IntPtr parentHandle, IntPtr childAfter, string className, string windowTitle);
    System.Timers.Timer aTimer = new System.Timers.Timer();
    private void request_refresh()
    {
        WebBrowserReadyState state1 = WebBrowserReadyState.Complete;
        webBrowser1.Invoke(new Action(() => webBrowser1.ScriptErrorsSuppressed = true));
        webBrowser1.Invoke(new Action(() => webBrowser1.Refresh(WebBrowserRefreshOption.Completely)));
        while (state1 != WebBrowserReadyState.Complete)
        {
            Application.DoEvents();
        }
        aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
        aTimer.Interval = 10;
        aTimer.Enabled = true;
    }
    private void OnTimedEvent(object source, ElapsedEventArgs exc)
    {
        try
        {
            var handle = IntPtr.Zero;
            handle = FindWindowEx(IntPtr.Zero, handle, "#32770", "Web-browser");
            if (!handle.Equals(IntPtr.Zero))
            {
                if (SetForegroundWindow(handle))
                {
                    SendKeys.SendWait("{ENTER}");
                    aTimer.Stop();
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString());
        }
    }
