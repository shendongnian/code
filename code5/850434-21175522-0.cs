    public double ScrollPosition
    {
        get { return (double)GetValue(ViewPortProperty); }
        set { SetValue(ViewPortProperty, value); }
    }
    
    public static readonly DependencyProperty ViewPortProperty = DependencyProperty.Register(
        "ScrollPosition", 
        typeof(double), 
        typeof(MyLongListSelector), 
        new PropertyMetadata(0d, OnViewPortChanged));
