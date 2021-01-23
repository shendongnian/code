    public class ScollViewerEndListener :FrameworkElement
    {
        public event EventHandler EndOfScrollReached;
        private ScrollViewer scrollViewer;
        public ScollViewerEndListener()
        {
            
        }
        public void Init(ScrollViewer scrollViewer)
        {
            this.scrollViewer = scrollViewer;
            var binding = new Binding
            {
                Source = scrollViewer,
                Path = new PropertyPath("VerticalOffset"),
                Mode = BindingMode.OneWay
            };
            SetBinding(ListVerticalOffsetProperty, binding);
        }
        
        private void OnListVerticalOffsetChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            var atBottom = scrollViewer.VerticalOffset >= scrollViewer.ScrollableHeight;
            if (atBottom)
            {
                if (EndOfScrollReached != null)
                {
                    EndOfScrollReached(this, null);
                }
            }
        }
        public readonly DependencyProperty ListVerticalOffsetProperty;
        public double ListVerticalOffset
        {
            get { return (double)GetValue(ListVerticalOffsetProperty); }
            set { SetValue(ListVerticalOffsetProperty, value); }
        }
    }
