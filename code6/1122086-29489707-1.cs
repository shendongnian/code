    [TypeConverter(typeof(StringToDoubleTypeConverter<double>))]
    public double FontSize
    {
        get { return (double)GetValue(CustomHeightProperty); }
        set { SetValue(CustomHeightProperty, value); }
    }
