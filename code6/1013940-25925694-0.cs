    public static readonly DependencyProperty ItemProperty = 
        DependencyProperty.Register(
            "Item", typeof(LayerItem), typeof(LayerControl));
    public LayerItem Item
    {
        get { return (LayerItem)GetValue(ItemProperty); }
        set { SetValue(ItemProperty, value); }
    }
