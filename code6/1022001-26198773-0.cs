    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
         const int WM_DROPFILES = 0x233;
        [DllImport("shell32.dll")]
        static extern void DragAcceptFiles(IntPtr hwnd, bool fAccept);
        [DllImport("shell32.dll")]
        static extern uint DragQueryFile(IntPtr hDrop, uint iFile, [Out] StringBuilder filename, uint cch);
        [DllImport("shell32.dll")]
        static extern void DragFinish(IntPtr hDrop);
        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);
            var helper = new WindowInteropHelper(this);
            var hwnd = helper.Handle;
            HwndSource source = PresentationSource.FromVisual(this) as HwndSource;
             source.AddHook(WndProc);
            DragAcceptFiles(hwnd, true);
        }
        private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            if (msg == WM_DROPFILES) 
            {
                handled = true;
                return HandleDropFiles(wParam);
            }
            return IntPtr.Zero;
        }
        private IntPtr HandleDropFiles(IntPtr hDrop)
        {
            this.info.Text = "Dropped!";
            const int MAX_PATH = 260;
            var count = DragQueryFile(hDrop, 0xFFFFFFFF, null, 0);
            for (uint i = 0; i < count; i++)
            {
                int size = (int) DragQueryFile(hDrop, i, null, 0);
                var filename = new StringBuilder(size + 1);
                DragQueryFile(hDrop, i, filename, MAX_PATH);
                Debug.WriteLine("Dropped: " + filename.ToString());
            }
            DragFinish(hDrop);
            return IntPtr.Zero;
        }
    }
