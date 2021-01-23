    public static string GetMyCustom(DependencyObject obj)
    {
        return (string)obj.GetValue(MyCustomProperty);
    }
    public static void SetMyCustom(DependencyObject obj, string value)
    {
        obj.SetValue(MyCustomProperty, value);
    }
