    public partial class Form1 : Form
    {
        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        static extern IntPtr FindWindowByCaption(IntPtr ZeroOnly, string lpWindowName);
    
        [DllImport("user32.Dll")]
        static extern int PostMessage(IntPtr hWnd, UInt32 msg, int wParam, int lParam);
    
        const UInt32 WM_CLOSE = 0x0010;
    
        public Form1()
        {
            InitializeComponent();
    
            Thread thread = new Thread(ShowAutoClosingMessageBox);
            thread.Start();
        }
    
        private static void ShowAutoClosingMessageBox()
        {
            var timer = new System.Timers.Timer(5000) { AutoReset = false };
            timer.Elapsed += delegate
            {
                IntPtr hWnd = FindWindowByCaption(IntPtr.Zero, "Caption");
                if (hWnd.ToInt32() != 0) PostMessage(hWnd, WM_CLOSE, 0, 0);
            };
            timer.Start();
            MessageBox.Show("Message", "Caption");
        }
    }
