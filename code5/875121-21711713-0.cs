    public class WatermarkTextBox : TextBox
    {
        public WatermarkTextBox()
        {
            TextChanged += OnTextChanged;    
        }
        private void OnTextChanged(object sender, TextChangedEventArgs textChangedEventArgs)
        {
            // Show or hide the watermark based on the text length
            if (Text.Length > 0)
            {
                WatermarkVisibility = Visibility.Collapsed;
            }
            else
            {
                WatermarkVisibility = Visibility.Visible;
            }
        }
        public string Watermark
        {
            get { return (string)GetValue(WatermarkProperty); }
            set { SetValue(WatermarkProperty, value); }
        }
        // Using a DependencyProperty as the backing store for Watermark.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty WatermarkProperty =
            DependencyProperty.Register("Watermark", typeof(string), typeof(WatermarkTextBox), new PropertyMetadata(null));
        public Visibility WatermarkVisibility
        {
            get { return (Visibility)GetValue(WatermarkVisibilityProperty); }
            set { SetValue(WatermarkVisibilityProperty, value); }
        }
        // Using a DependencyProperty as the backing store for WatermarkVisibility.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty WatermarkVisibilityProperty =
            DependencyProperty.Register("WatermarkVisibility", typeof(Visibility), typeof(WatermarkTextBox), new PropertyMetadata(System.Windows.Visibility.Visible));
    }
