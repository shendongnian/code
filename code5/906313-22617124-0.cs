    public partial class UserControl2 : UserControl
    {
        bool _pinned;
        Point _offset;
        public UserControl2()
        {
            InitializeComponent();
        }
        private void B2_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            var control = (UIElement)sender;
            control.CaptureMouse();
            _offset = e.GetPosition(control);
            _pinned = true;
        }
        private void ui2_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_pinned)
                return;
            var control = (FrameworkElement)sender;
            var parent = (FrameworkElement)control.Parent;
            Canvas.SetLeft(control, e.GetPosition(parent).X - _offset.X);
            Canvas.SetTop(control, e.GetPosition(parent).Y - _offset.Y);
            e.Handled = true;
        }
        private void B2_OnMouseUp(object sender, MouseButtonEventArgs e)
        {
            _pinned = false;
            var control = (UIElement)sender;
            control.ReleaseMouseCapture();
            e.Handled = true;
        }
    }
