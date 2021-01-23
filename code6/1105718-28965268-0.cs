    public string FormatText
        {
            get { return (string)GetValue(FormatTextProperty); }
            set { SetValue(FormatTextProperty, value); }
        }
        // Using a DependencyProperty as the backing store for FormatText.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty FormatTextProperty =
            DependencyProperty.Register("FormatText", typeof(string),
            typeof(CustomInkCanvas), new PropertyMetadata(string.Empty));
