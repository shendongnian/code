    public static void SetRectangleBackground(DependencyObject DepObject, Brush value)
    {
        DepObject.SetValue(RectangleBackgroundProperty, value);
    }
    public static Brush GetRectangleBackground(DependencyObject DepObject)
    {
        return (Brush)DepObject.GetValue(RectangleBackgroundProperty);
    }
