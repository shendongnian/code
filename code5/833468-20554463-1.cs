    Binding weekHeight = new Binding 
    {
        Path = new PropertyPath(SizeChange.ActualHeightProperty),
        Mode = BindingMode.OneWay,
        Source = border
    };
    border2.SetBinding( Border.HeightProperty, weekHeight );
