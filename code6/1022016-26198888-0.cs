    public class ResizeWindow : Window
    {
        public ResizeWindow()
        {
            this.Loaded += ResizeWindow_Loaded;
        }
        void ResizeWindow_Loaded(object sender, RoutedEventArgs e)
        {
            HwndSource source = HwndSource.FromHwnd(new WindowInteropHelper(this).Handle);
            source.AddHook(new HwndSourceHook(WndProc));
        }
        public event EventHandler Resizing;
        public event EventHandler Resized;
        private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            const int WM_ENTERSIZEMOVE = 0x0231;
            const int WM_EXITSIZEMOVE = 0x0232;
            if (msg == WM_ENTERSIZEMOVE)
            {
                if(Resizing != null)
                {
                    Resizing(this, EventArgs.Empty);
                }
            }
            else if (msg == WM_EXITSIZEMOVE)
            {
                if (Resized != null)
                {
                    Resized(this, EventArgs.Empty);
                }
            }
            
            return IntPtr.Zero;
        }
    }
