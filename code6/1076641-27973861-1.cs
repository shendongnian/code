    public static readonly DependencyProperty ValueProperty = 
         DependencyProperty.Register(
             "Value", 
             typeof(decimal?),
             typeof(CurrencyTextBox),
             new FrameworkPropertyMetadata(
                         new decimal?(), 
                         FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, 
                         new PropertyChangedCallback(ValuePropertyChanged)));
    private static void ValuePropertyChanged(
                             DependencyObject d,
                             DependencyPropertyChangedEventArgs e)
    {
        CurrencyTextBox x = (CurrencyTextBox)d;
        x.Value = (decimal?)e.NewValue;
    }
