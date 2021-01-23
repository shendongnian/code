    public ColumnDataControl() { }
    
    ObservableCollection<data> CollectionOfData { get; set; }
    
    private button_click(object sender, RoutedEventArgs e)
    {
    	CollectionOfData.Add(...);
    }
