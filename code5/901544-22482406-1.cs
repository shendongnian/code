    public object SingletonItem
	{
		get { return (object) GetValue(SingletonItemProperty); }
		set { SetValue(SingletonItemProperty, value); }
	}
    public static readonly DependencyProperty SingletonItemProperty =
			DependencyProperty.Register("SingletonItem", typeof (object), typeof (BindableTabControl),
			new PropertyMetadata(OnSingletonItemChanged));
    public static void OnSingletonItemChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        ((BindableTabControl) d).UpdateItems();
    }
    private void UpdateItems()
    {
        //it is up to you to implement this method, so this is only a sketch
        //the null check for SingletonItem is missing too
        if (IsNullOrEmpty(MyItemsSource))
        {
            Items = Enumerable.FromSingleItem(SingletonItem);
        } else {
            Items = MyItemsSource;
        }
    }
    ...
    public static void OnMyItemsSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if ( e.OldValue != null ) { RemoveItemsChangedEventHandlers( e.OldValue as INotifyCollectionChanged ); }
        if ( MyItemsSource != null ) { AddItemsChangedEventHandlers( MyItemsSource as INotifyCollectionChanged ); }
        ((BindableTabControl) d).UpdateItems();
    }
    private void MyItemsSourceItemsChanged(...)
    {
        ((BindableTabControl) d).UpdateItems();
    }
