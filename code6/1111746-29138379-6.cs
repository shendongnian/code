    public class ScrollViewerEx : ScrollViewer {
        public static readonly DependencyProperty IsScrollingWithMouseWheelProperty = DependencyProperty.Register(
            "IsScrollingWithMouseWheel", typeof (bool), typeof (ScrollViewerEx), new FrameworkPropertyMetadata(false));
        public bool IsScrollingWithMouseWheel {
            get { return (bool) GetValue(IsScrollingWithMouseWheelProperty); }
            set { SetValue(IsScrollingWithMouseWheelProperty, value); }
        }
        private readonly DispatcherTimer mouseWheelActivityTimer;
        public ScrollViewerEx() {
            mouseWheelActivityTimer = new DispatcherTimer();
            mouseWheelActivityTimer.Interval = TimeSpan.FromSeconds(1);
            mouseWheelActivityTimer.Tick += MouseWheelActivityTimerOnTick;
        }
        private void MouseWheelActivityTimerOnTick(object sender, EventArgs eventArgs) {
            mouseWheelActivityTimer.Stop();
            IsScrollingWithMouseWheel = false;
        }
        protected override void OnMouseWheel(MouseWheelEventArgs e) {
            mouseWheelActivityTimer.Stop();
            IsScrollingWithMouseWheel = true;
            mouseWheelActivityTimer.Start();
            base.OnMouseWheel(e);
        }
    }
