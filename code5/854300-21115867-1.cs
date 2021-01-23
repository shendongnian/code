    public static readonly DependencyProperty MyPropertyProperty =
        DependencyProperty.Register(
            "MyProperty",
            typeof(object),
            typeof(OwnerType),
            new PropertyMetadata(default(object), null, CoerceMyProperty));
    private static object CoerceMyProperty(DependencyObject d, object baseValue)
    {
        if (baseValue == null)
            return SomeValidValue;
        return baseValue;
    }
