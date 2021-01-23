    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            KeyUp += MainWindow_KeyUp;
        }
        protected override void OnKeyUp(KeyEventArgs e)
        {
            Log("KeyUp overridde: {0}", e.Key);
            base.OnKeyUp(e);
        }
        private void MainWindow_KeyUp(object sender, KeyEventArgs e)
        {
            Log("KeyUp event: {0}", e.Key);
        }
        private const int WM_SYSCOMMAND = 0x0112;
        private const int SC_KEYMENU = 0xF100;
        private const int NO_KEYPRESS = 0;
        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);
            HwndSource source = PresentationSource.FromVisual(this) as HwndSource;
            source.AddHook(this.WndProc);
        }
        private void Log(string msg, params object[] args)
        {
            Debugger.Log(0, string.Empty, string.Format(msg, args));
        }
        private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            // Handle messages...
            if (msg == WM_SYSCOMMAND)
            {
                if (wParam.ToInt32() == SC_KEYMENU)
                {
                    int iLParam = lParam.ToInt32();
                    Log($"Key: {(char)iLParam} ");
                    if (lParam.ToInt32() == NO_KEYPRESS)
                    {
                        handled = true;
                    }
                }
            }
            return IntPtr.Zero;
        }
    }
