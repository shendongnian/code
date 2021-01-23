    public partial class MainWindow : Window
    {
        [DllImport("User32.dll")]
        private static extern bool SetCursorPos(int X, int Y);
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            SetCursor(200, 200);
        }
        private static void SetCursor(int x, int y)
        {
            // Left boundary
            var xL = (int)App.Current.MainWindow.Left;
            // Top boundary
            var yT = (int)App.Current.MainWindow.Top;
            SetCursorPos(x + xL, y + yT);
        }
    }
