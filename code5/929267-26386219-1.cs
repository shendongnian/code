    public class FrameworkElementExtender : FrameworkElement
    {
        public new static readonly DependencyProperty VisibilityProperty = DependencyProperty.Register(
            "Visibility", typeof(Visibility), typeof(FrameworkElementExtender), new PropertyMetadata(default(Visibility), PropertyChangedCallback));
        private static void PropertyChangedCallback(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            ((FrameworkElementExtender)o).OnVisibilityChanged((System.Windows.Visibility)e.NewValue);
        }
        public new Visibility Visibility
        {
            get { return (Visibility)GetValue(VisibilityProperty); }
            set { SetValue(VisibilityProperty, value); }
        }
        private readonly FrameworkElement _element;
        public FrameworkElementExtender(FrameworkElement element)
        {
            _element = element;
            var binding = new Binding("Visibility")
            {
                Source = element,
            };
            SetBinding(VisibilityProperty, binding);
        }
        public event EventHandler<VisibilityChangedEventArgs> VisibilityChanged;
        protected virtual void OnVisibilityChanged(Visibility visible)
        {
            var handler = VisibilityChanged;
            if (handler != null)
                handler(this, new VisibilityChangedEventArgs(visible));
        }
    }
