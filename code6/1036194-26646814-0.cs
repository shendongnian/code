    // SingleInstance.cs
    static public class SingleInstance
    {
        public const string ProgramGuid = "E2A5E185-7C2D-4A4A-97D2-D50378ADD2E3";
        public static readonly int WM_SHOWFIRSTINSTANCE = WinApi.RegisterWindowMessage("WM_SHOWFIRSTINSTANCE|{0}", ProgramGuid);
        static Mutex mutex;
        static public bool Start()
        {
            string mutexName = String.Format("Local\\{0}", ProgramGuid);
            bool onlyInstance;
            mutex = new Mutex(true, mutexName, out onlyInstance);
            return onlyInstance;
        }
        static public void ShowFirstInstance()
        {
            WinApi.PostMessage((IntPtr)WinApi.HWND_BROADCAST, WM_SHOWFIRSTINSTANCE, IntPtr.Zero, IntPtr.Zero);
        }
        static public void Stop()
        {
            mutex.ReleaseMutex();
        }
    }    
    // Main.cs
    public static void Main()
    {
        if (!SingleInstance.Start())
        {
            SingleInstance.ShowFirstInstance();
            return;
        }
    
        var app = new App();
        app.Run();
        SingleInstance.Stop();
    }
    // MainWindow.xaml.cs
    protected override void OnSourceInitialized(EventArgs e)
    {
        base.OnSourceInitialized(e);
        var source = PresentationSource.FromVisual(this) as HwndSource;
        source.AddHook(WndProc);
    }
    private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
    {
        if (msg == SingleInstance.WM_SHOWFIRSTINSTANCE)
        {
            this.Show();
            WinApi.ShowToFront(hwnd);
            handled = true;
        }
        return IntPtr.Zero;
    }
