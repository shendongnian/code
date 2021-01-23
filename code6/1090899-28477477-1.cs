    public partial class MainWindow : Window
    {
        [DllImport("user32.dll")]
        static extern IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);
    
        [DllImport("user32.dll", SetLastError = true)]
        public static extern bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);
    
        private Process pDocked;
        private IntPtr hWndOriginalParent;
        private IntPtr hWndDocked;
        public System.Windows.Forms.Panel pannel;
    
        public MainWindow()
        {
            InitializeComponent();
            var host = new WindowsFormsHost();
            pannel = new System.Windows.Forms.Panel();
            host.Child = pannel;
            this.Content = host;
            dockIt("notepad.exe");
        }
    
        private void dockIt(string utility)
        {
            if (hWndDocked != IntPtr.Zero) //don't do anything if there's already a window docked.
                return;
    
            pDocked = Process.Start(utility);
            while (hWndDocked == IntPtr.Zero)
            {
                pDocked.WaitForInputIdle(1000); //wait for the window to be ready for input;
                pDocked.Refresh();              //update process info
                if (pDocked.HasExited)
                {
                    return; //abort if the process finished before we got a handle.
                }
                hWndDocked = pDocked.MainWindowHandle;  //cache the window handle
            }
            //Windows API call to change the parent of the target window.
            //It returns the hWnd of the window's parent prior to this call.
            hWndOriginalParent = SetParent(hWndDocked, pannel.Handle);
    
            //Wire up the event to keep the window sized to match the control
            SizeChanged += window_SizeChanged;
            //Perform an initial call to set the size.
            AlignToPannel();
        }
    
        private void AlignToPannel()
        {
            MoveWindow(hWndDocked, 0, 0, pannel.Width, pannel.Height, true);
        }
    
        void window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            AlignToPannel();
        }
    }
