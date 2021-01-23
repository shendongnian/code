    public static readonly DependencyProperty CurrentMapProperty = 
       DependencyProperty.Register(
         "State", typeof(eMap), typeof(mPolygon), new PropertyMetadata(false, OnStateChanged));
    private static readonly IDictionary<eMap, ImageBrush> mapping = new Dictionary<eMap, ImageBrush>
    {
        { eMap.Map1, Map1 },
        { eMap.Map1, Map2 },
        { eMap.Map1, Map3 }
    };
    private static void OnStateChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
 	    mPolygon polygon = (mPolygon)d;
        polygon.Fill = mapping[e.NewValue];
    }
