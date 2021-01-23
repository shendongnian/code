    public static DependencyProperty ItemsProperty = DependencyProperty.Register("Items", typeof(ObservableCollection<string>), typeof(YourWindowOrUserControl));
    public ObservableCollection<string> Items
    {
        get { return (ObservableCollection<string>)GetValue(ItemsProperty); }
        set { SetValue(ItemsProperty, value); }
    }
    ...
    Items = new ObservableCollection<string>(File.ReadLines(@"bookmarks.txt"));
