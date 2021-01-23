    public static readonly DependencyProperty StrProperty =
        DependencyProperty.Register(
            "Str", typeof(string), typeof(CustomLabel),
            new PropertyMetadata(StrPropertyChanged));
    private static void StrPropertyChanged(
        DependencyObject obj, DependencyPropertyChangedEventArgs e)
    {
        var label = obj as CustomLabel;
        var str = e.NewValue as string;
        ...
    }
