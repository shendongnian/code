    public static readonly DependencyProperty ItemsListProperty =
        DependencyProperty.Register("ItemsList", typeof(IEnumerable), typeof(Matrix),
            new PropertyMetadata(new PropertyChangedCallback(ItemsListChanged)));
    
    public IEnumerable ItemsList
    {
        get { return (IEnumerable)GetValue(ItemsListProperty); }
        set { SetValue(ItemsListProperty, value); }
    }
