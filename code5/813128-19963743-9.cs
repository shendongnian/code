    public partial class MainWindow : Window
    {
        public MainWindow()
        {  
            InitializeComponent();
        }
        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);
            HwndSource source = PresentationSource.FromVisual(this) as HwndSource;
            source.AddHook(WndProc);
        }
        public IntPtr WndProc(IntPtr hwnd, int msg, 
                              IntPtr wParam, IntPtr iParam, ref bool handled)
        {
            if (msg == NativeMethods.HWND_IPC)
                MessageBox.Show("Message Received!");
            return IntPtr.Zero;
        }
    }
    internal class NativeMethods
    {
        
    etc. etc.
