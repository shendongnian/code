    public static readonly DependencyProperty DataPointsProperty = 
        DependencyProperty.Register(
            "DataPoints",                                       //Property Name
            typeof(IList<DataPoint>),                            //CLR-Property Type
            typeof(MyCustomControl),                            //Custom Control Type
            new FrameworkPropertyMetadata(
                default(IList<DataPoint>),                      //Default Value.
                FrameworkPropertyMetadataOptions.AffectsRender, //Re-render if changed,
                OnDataPointsPropertyChanged
            )
        );
    private static void OnDataPointsPropertyChanged(
        DependencyObject d,
        DependencyPropertyChangedEventArgs e)
    {
        var control = (MyCustomControl)d;
        var oldValue = e.OldValue as INotifyCollectionChanged;
        var newValue = e.NewValue as INotifyCollectionChanged;
        if (oldValue != null)
            oldValue.CollectionChanged -= control.OnDataPointsCollectionChanged;
        if (newValue != null)
            newValue.CollectionChanged += control.OnDataPointsCollectionChanged;
    }
    private void OnDataPointsCollectionChanged(
        object s,
        NotifyCollectionChangedEventArgs e)
    {
        this.InvalidateVisual();
    }
