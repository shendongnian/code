    [TypeConverter(typeof(StringToDoubleTypeConverter<double>))]
    public double FontSize
    {
        get { return (double)GetValue(FontSizeProperty); }
        set { SetValue(FontSizeProperty, value); }
    }
