    // ... Here registered property
    public static void SetZoomValue(DependencyObject DepObject, int value)
    {
        DepObject.SetValue(ZoomValueProperty, value);
    }
    public static int GetZoomValue(DependencyObject DepObject)
    {
        return (int)DepObject.GetValue(ZoomValueProperty);
    }
    // ... Somewhere in handler
    int value = GetZoomValue(plotControl);
