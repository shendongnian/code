    public partial class Form1 : Form
    {
        Dictionary<int, string> Windows = new Dictionary<int, string>();
        public delegate bool WindowEnumCallback(int hwnd, int lparam);
        [DllImport("user32.dll")]
        public static extern bool EnumWindows(WindowEnumCallback lpEnumFunc, int lParam);
        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);
        [DllImport("user32.dll")]
        public static extern bool IsWindowVisible(int h);
        [DllImport("user32.dll")]
        public static extern void GetWindowText(int h, StringBuilder s, int nMaxCount);
        public Form1()
        {
            InitializeComponent();
            EnumWindows(new WindowEnumCallback(AddWnd), 0);
            foreach (var item in Windows)
            {
                SetForegroundWindow((IntPtr)item.Key);
            }
        }
        private bool AddWnd(int hwnd, int lparam)
        {
            if (IsWindowVisible(hwnd))
            {
                StringBuilder sb = new StringBuilder(255);
                GetWindowText(hwnd, sb, sb.Capacity);
                if (sb.Length > 0 && sb.ToString() != this.Name)
                    Windows.Add(hwnd, sb.ToString());
            }
            return true;
        }
    }
