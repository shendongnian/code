    public static readonly DependencyProperty IsFormattedProperty = DependencyProperty.RegisterAttached("IsFormatted", typeof(bool), typeof(TextBoxProperties), new UIPropertyMetadata(default(bool), OnIsFormattedChanged));
    public static bool GetIsFormatted(DependencyObject dependencyObject)
    {
        return (bool)dependencyObject.GetValue(IsFormattedProperty);
    }
    public static void SetIsFormatted(DependencyObject dependencyObject, bool value)
    {
        dependencyObject.SetValue(IsFormattedProperty, value);
    }
    public static void OnIsFormattedChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
    {
        TextBox textBox = dependencyObject as TextBox;
        if (textBox != null)
        {
            bool newIsFormattedValue = (bool)dependencyPropertyChangedEventArgs.NewValue;
            if (newIsFormattedValue) textBox.TextChanged += YourTextChangedHandler;
            else textBox.TextChanged -= YourTextChangedHandler;
        }
    }
