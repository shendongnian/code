    public static DependencyProperty PreviewKeyDownProperty = DependencyProperty.RegisterAttached("PreviewKeyDown", typeof(KeyEventHandler), typeof(TextBoxProperties), new UIPropertyMetadata(null, OnPreviewKeyDownChanged));
    public static KeyEventHandler GetPreviewKeyDown(DependencyObject dependencyObject)
    {
        return (KeyEventHandler)dependencyObject.GetValue(PreviewKeyDownProperty);
    }
    public static void SetPreviewKeyDown(DependencyObject dependencyObject, KeyEventHandler value)
    {
        dependencyObject.SetValue(PreviewKeyDownProperty, value);
    }
    public static void OnPreviewKeyDownChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
    {
        TextBox textBox = dependencyObject as TextBox;
        if (e.OldValue == null && e.NewValue != null) textBox.PreviewKeyDown += TextBox_PreviewKeyDown;
        else if (e.OldValue != null && e.NewValue == null) textBox.PreviewKeyDown -= TextBox_PreviewKeyDown;
    }
    private static void TextBox_PreviewKeyDown(object sender, KeyEventArgs e)
    {
        TextBox textBox = sender as TextBox;
        KeyEventHandler eventHandler = GetPreviewKeyDown(textBox);
        if (eventHandler != null) eventHandler(sender, e);
    }
