    public static DependencyProperty YourCollectionProperty = DependencyProperty.Register(
        "YourCollection", typeof(ObservableCollection<string>), typeof(YourUserControl));
    public ObservableCollection<string> YourCollection
    {
        get { return (ObservableCollection<string>)GetValue(YourCollectionProperty); }
        set { SetValue(YourCollectionProperty, value); }
    }
