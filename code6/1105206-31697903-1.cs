        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(string), typeof(MyViewModel),
                                                                                          new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
    public string Value
    {
        get { return (string)GetValue(ValueProperty); } // GetValue() is from derived DependencyObject class
        set { SetValue(ValueProperty, value); }         // SetValue() is from derived DependencyObject class
    }
