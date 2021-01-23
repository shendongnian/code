    // Quick and dirty sample...
    public partial class MainWindow : Window
    {
        [DllImport("User32.dll")]
        private static extern bool SetCursorPos(int X, int Y);
        public MainWindow()
        {
            InitializeComponent();
            SetCursorPos(100, 100);
        }
    }
