    public static readonly DependencyProperty ItemsSourceProperty =
        DependencyProperty.Register("ItemsSource", 
        typeof(ObservableCollection<BaseDataType>), typeof(ListWithTitle), 
        new PropertyMetadata(default(IEnumerable)));
    
    public ObservableCollection<BaseDataType> ItemsSource {
        get { return (ObservableCollection<BaseDataType>)GetValue(ItemsSourceProperty); }
        set { SetValue(ItemsSourceProperty, value); }
    }
