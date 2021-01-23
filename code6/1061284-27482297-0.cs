    public static readonly DependencyProperty TextProperty = DependencyProperty.Register(
        "Text", typeof (string), typeof (ColorPicker), new PropertyMetadata(default(string), OnTextChanged));
    private static void OnTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        var control = d as UserControl;
        if (null == control) return; // This should not be possible
        var newValue = e.NewValue as string;
        if (null == newValue) return;
        var split = newValue.Split(':');
        control.Text1 = split.ElementAtOrDefault(0);
        control.Text2 = split.ElementAtOrDefault(1);
    }
    public string Text
    {
        get { return (string) GetValue(TextProperty); }
        set { SetValue(TextProperty, value); }
    }
