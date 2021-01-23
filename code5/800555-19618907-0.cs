    public static readonly DependencyProperty SelectedItemProperty = DependencyProperty.
        Register("SelectedItem", typeof(YourDataType), typeof(YourControl), 
        new UIPropertyMetadata(null, OnSelectedItemPropertyChanged));
    public YourDataType SelectedItem 
    {
        get { return (YourDataType)GetValue(SelectedItemProperty); }
        set { SetValue(SelectedItemProperty, value); }
    }
    private static void OnSelectedItemPropertyChanged(DependencyObject sender, 
        DependencyPropertyChangedEventArgs e)
    {
        // User has selected an item
    }
    ...
    private void Control_PreviewKeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter || e.Key == Key.Return)
        {
            // User pressed Enter... do something with SelectedItem property here
        }
    }
