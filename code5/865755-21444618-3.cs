    public static DependencyProperty InnerContentProperty = DependencyProperty.Register("InnerContent", typeof(UIElement), typeof(YourControl));
    public UIElement InnerContent
    {
        get { return (UIElement)GetValue(InnerContentProperty); }
        set { SetValue(InnerContentProperty, value); }
    }
