    namespace DraggableWindow
    {
        public sealed partial class MainPage : Page
        {
            public MainPage()
            {
                this.InitializeComponent();
            }
            private uint pointerId;
            private Point lastPoint;
            private void OnWindowPointerPressed(object sender, PointerRoutedEventArgs e)
            {
                if (e.Pointer.PointerDeviceType == PointerDeviceType.Mouse)
                {
                    window.CapturePointer(e.Pointer);
                    this.pointerId = e.Pointer.PointerId;
                    this.lastPoint = e.GetCurrentPoint(window).Position;
                }
            }
            private void OnWindowPointerMoved(object sender, PointerRoutedEventArgs e)
            {
                if (e.Pointer.IsInContact &&
                    e.Pointer.PointerId == pointerId)
                {
                    var point = e.GetCurrentPoint(window).Position;
                    this.scrollViewer.ChangeView(
                        this.scrollViewer.HorizontalOffset - point.X + lastPoint.X,
                        this.scrollViewer.VerticalOffset - point.Y + lastPoint.Y,
                        null,
                        true);
                }
            }
            private void OnWindowPointerReleased(object sender, PointerRoutedEventArgs e)
            {
                if (e.Pointer.PointerId == pointerId)
                {
                    window.ReleasePointerCapture(e.Pointer);
                }
            }
            private void OnScrollViewerSizeChanged(object sender, SizeChangedEventArgs e)
            {
                UpdateWindowingLayout();
            }
            private void OnWindowSizeChanged(object sender, SizeChangedEventArgs e)
            {
                UpdateWindowingLayout();
            }
            private void UpdateWindowingLayout()
            {
                this.panel.Width = this.scrollViewer.ViewportWidth * 2 - 0.0 * this.window.ActualWidth;
                this.panel.Height = this.scrollViewer.ViewportHeight * 2 - 0.5 * this.window.ActualHeight;
                Canvas.SetLeft(this.window, this.scrollViewer.ViewportWidth - 0.5 * this.window.ActualWidth);
                Canvas.SetTop(this.window, this.scrollViewer.ViewportHeight - 0.5 * this.window.ActualHeight);
            }
        }
    }
