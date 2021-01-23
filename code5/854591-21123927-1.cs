    public partial class RotatableUserControl : UserControl
    {
        private Point _center;
        public RotatableUserControl()
        {
            InitializeComponent();
        }
        public void OnDragStarted(object sender, DragStartedEventArgs e)
        {
            var thumb = (Thumb)sender;
            _center = new Point(thumb.ActualWidth/2, thumb.ActualHeight/2);
            thumb.RenderTransform = (thumb.RenderTransform as RotateTransform) ?? new RotateTransform(0, _center.X, _center.Y);
        }
        public void OnDragDelta(object sender, DragDeltaEventArgs e)
        {
            var thumb = (Thumb)sender;
            var pos = Mouse.GetPosition(thumb);
            var rotate = (RotateTransform)thumb.RenderTransform;
            double angle = Math.Atan((pos.X-_center.X) / (pos.Y-_center.Y));
            rotate.Angle += angle;
        }
        public void OnDragCompleted(object sender, DragCompletedEventArgs e)
        {
            var thumb = (Thumb)sender;
        }
    }
