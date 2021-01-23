    public static readonly DependencyProperty ItemsProperty = DependencyProperty.Register(
        "Items", typeof(ObservableCollection<Image>), typeof(MainWindow), 
        new UIPropertyMetadata(new ObservableCollection<Image>()));
    public ObservableCollection<Image> Items
    {
        get { return (ObservableCollection<Image>)GetValue(ItemsProperty); }
        set { SetValue(ItemsProperty, value); }
    }
