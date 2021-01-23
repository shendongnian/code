    public static readonly DependencyProperty IsCheckedOnDataProperty;
    public static void SetIsCheckedOnData(DependencyObject DepObject, DrawingBrush value)
    {
        DepObject.SetValue(IsCheckedOnDataProperty, value);
    }
    public static DrawingBrush GetIsCheckedOnData(DependencyObject DepObject)
    {
        return (DrawingBrush)DepObject.GetValue(IsCheckedOnDataProperty);
    }
    static CustomCheckBoxClass()
    {
        PropertyMetadata MyPropertyMetadata = new PropertyMetadata(null);
        IsCheckedOnDataProperty = DependencyProperty.RegisterAttached("IsCheckedOnData",
                                                                typeof(DrawingBrush),
                                                                typeof(CustomCheckBoxClass),
                                                                MyPropertyMetadata);
    }
