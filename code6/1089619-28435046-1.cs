    public PropertiesDialog(Brush foreground, Brush background)
    {
        InitializeComponent();
        var solidForeground = foreground as SolidColorBrush;
        var solidBackground = background as SolidColorBrush;
        if (solidForeground == null || solidBackground == null)
        {
            // One or both of the brushes does not have a
            // single solid colour; what you do here is up to you
            throw new InvalidOperationException();
        }
        FontColorPicker.SelectedColor = solidForeground.Color;
        BgColorPicker.SelectedColor = solidBackground.Color;
    }
