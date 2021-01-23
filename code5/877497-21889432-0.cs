    public static readonly DependencyProperty ItemsSourceProperty =
        DependencyProperty.Register("ItemsSource", typeof(IList), 
                                    typeof(ListWithTitle));
    
    public IList ItemsSource
    {
        get { return (ObservableCollection<object>)GetValue(ItemsSourceProperty); }
        set { SetValue(ItemsSourceProperty, value); }
    }
