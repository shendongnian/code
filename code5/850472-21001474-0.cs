    public static readonly DependencyProperty ItemsProperty = DependencyProperty.Register(
        "Items", typeof(ObservableCollection<string>), typeof(YourControlType));
    public ObservableCollection<string> Items
    {
        get { return (ObservableCollection<string>)GetValue(ItemsProperty); }
        set { SetValue(ItemsProperty, value); }
    }
