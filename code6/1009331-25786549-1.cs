    public const string DescriptionBrushPropertyName = "DescriptionBrush";
    public Brush DescriptionBrush
    {
        get
        {
            return (Brush)GetValue(DescriptionBrushProperty);
        }
        set
        {
            SetValue(DescriptionBrushProperty, value);
        }
    }
    public static readonly DependencyProperty DescriptionBrushProperty = DependencyProperty.Register(
        DescriptionBrushPropertyName,
        typeof(Brush),
        typeof(ExtendedToggleButton),
        new UIPropertyMetadata(new SolidColorBrush(Colors.White)));
