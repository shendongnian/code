    public partial class LogSlider : Slider
    {
        public LogSlider()
        {
            InitializeComponent();
            var metadata = new FrameworkPropertyMetadata();
            metadata.PropertyChangedCallback += ValuePropertyChangedCallback;
            ValueProperty.OverrideMetadata(typeof(LogSlider), metadata);
        }
        public double LogValue
        {
            get { return (double)GetValue(LogValueProperty);}
            set { SetValue(LogValueProperty, (value));}
        }
        public static readonly DependencyProperty LogValueProperty =
            DependencyProperty.Register("LogValue", typeof(double), typeof(LogSlider), new PropertyMetadata(0.0, LogValuePropertyChangedCallback));
        private static void LogValuePropertyChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
        {
            dependencyObject.SetValue(ValueProperty, Math.Exp((double)args.NewValue));
        }
        private static void ValuePropertyChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs args)
        {
            dependencyObject.SetValue(LogValueProperty, Math.Log((double)args.NewValue));
        }
    }
