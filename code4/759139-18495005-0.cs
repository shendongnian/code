    public static readonly DependencyProperty SortDirectionProperty =
        DependencyProperty.Register("SortDirection", 
                                     typeof(ListSortDirection), 
                                     typeof(MainWindow), 
                                     new PropertyMetadata(ListSortDirection.Ascending, SortDirectionPropertyChangedCallback));
    private static void SortDirectionPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
       (d as MainWindow).SortDirectionPropertyChangedCallback(e);
    }
    private void SortDirectionPropertyChangedCallback(DependencyPropertyChangedEventArgs e)
    {
       UpdateSort();
    }
    public ListSortDirection SortDirection
    {
        get { return (ListSortDirection)GetValue(SortDirectionProperty); }
        set { SetValue(SortDirectionProperty, value); }
    }
