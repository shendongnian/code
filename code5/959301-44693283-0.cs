    public static readonly DependencyProperty DataProperty 
        = DependencyProperty.Register("Data", typeof(DataType), typeof(MyView), 
           new FrameworkPropertyMetadata(default(DataType), 
               FrameworkPropertyMetadataOptions.AffectsRender));
    public DataType Data
    {
        get { return (DataType)GetValue(DataProperty); }
        set { SetValue(DataProperty, value); }
    }
