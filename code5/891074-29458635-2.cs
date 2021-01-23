    public partial class MainWindow : Window
    {
        // this is the offset of the mouse cursor from the top left corner of the window
        private Point offset = new Point();
        public MainWindow()
        {
            InitializeComponent();
        }
        private void OnMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // capturing the mouse here will redirect all events to this window, even if
            // the mouse cursor should leave the window area
            Mouse.Capture(this, CaptureMode.Element);
            Point cursorPos = PointToScreen(Mouse.GetPosition(this));
            Point windowPos = new Point(this.Left, this.Top);
            offset = (Point)(cursorPos - windowPos);
        }
        private void OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Mouse.Capture(null);
        }
        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (Mouse.Captured == this && Mouse.LeftButton == MouseButtonState.Pressed)
            {
                Point cursorPos = PointToScreen(Mouse.GetPosition(this));
                double newLeft = cursorPos.X - offset.X;
                double newTop = cursorPos.Y - offset.Y;
                // here you can change the window position and implement
                // the snapping behaviour that you need
                this.Left = newLeft;
                this.Top = newTop;
            }
        }
    }
