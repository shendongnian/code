    public static DependencyProperty ItemsProperty = DependencyProperty.Register("Items", typeof(ObservableCollection<string>), typeof(TestView));
    public ObservableCollection<string> Items
    {
        get { return (ObservableCollection<string>)GetValue(ItemsProperty); }
        set { SetValue(ItemsProperty, value); }
    }
