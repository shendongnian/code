    public bool ItemConverter
    {
        get { return (myConverterType)GetValue(IntemConverterProperty); }
        set { SetValue(ItemConverterProperty, value); }
    }
    
    public static readonly DependencyProperty ItemConverterProperty = 
        DependencyProperty.Register("ItemConverter", typeof(myConverterType), 
        typeof(LabeledComboBox), null);
