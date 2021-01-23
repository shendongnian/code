    public PropertiesDialog(Brush foreground, Brush background)
    {
        InitializeComponent();
        
        FontColorPicker.SelectedColor = ((SolidColorBrush)foreground).Color;
        BgColorPicker.SelectedColor = ((SolidColorBrush)background).Color; 
    }
