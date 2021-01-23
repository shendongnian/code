    public class WindowWrapper : System.Windows.Forms.IWin32Window
    {
        public WindowWrapper(IntPtr handle)
        {
            _hwnd = handle;
        }
    
        public IntPtr Handle
        {
            get { return _hwnd; }
        }
    
        private IntPtr _hwnd;
    }
    Process[] procs = Process.GetProcessesByName("Notepad");
    if (procs.Length != 0)
    {
        IntPtr hwnd = procs[0].MainWindowHandle;
        MessageBox.Show(new WindowWrapper(hwnd), "Hello World!");
    }
    else
        MessageBox.Show("Notepad is not running.");
