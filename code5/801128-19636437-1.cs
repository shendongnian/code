    public partial class Form1 : Form
    {
        [DllImport("user32.dll", EntryPoint = "FindWindow", SetLastError = true)]
        static extern IntPtr FindWindowByCaption(IntPtr ZeroOnly, string lpWindowName);
    
        [DllImport("user32.Dll")]
        static extern int PostMessage(IntPtr hWnd, UInt32 msg, int wParam, int lParam);
    
        const UInt32 WM_CLOSE = 0x0010;
    
        Thread thread;
    
        public Form1()
        {
            InitializeComponent();
    
            thread = new Thread(ShowMessageBox);
            thread.Start();
        }
    
        void CloseMessageBox()
        {
            IntPtr hWnd = FindWindowByCaption(IntPtr.Zero, "Caption");
            if (hWnd != IntPtr.Zero)
                PostMessage(hWnd, WM_CLOSE, 0, 0);
    
            if (thread.IsAlive)
                thread.Abort();
        }
    
        static void ShowMessageBox()
        {
            MessageBox.Show("Message", "Caption");
        }
    }
