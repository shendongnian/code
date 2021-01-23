        [DllImport("user32.DLL")]
        public static extern bool RegisterTouchWindow(IntPtr hwnd, int ulFlags);
        [DllImport("user32.DLL")]
        public static extern bool UnregisterTouchWindow(IntPtr hwnd);
        public Form1()
        {
            InitializeComponent();
            RegisterTouchWindow(button1.Handle, 0);
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            UnregisterTouchWindow(button1.Handle);
        }
