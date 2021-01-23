    public ObservableCollection<object> List { get; set; }
    
    public MainPage()
    {
         InitializeComponent();
         List = new ObservableCollection<object>() { "aaaa", "bbb", "cccc", "dddd", "eeee"};
         LongList.ItemsSource = List;
    }
    private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
    {
         var hyperLinkButton = sender as HyperlinkButton;
         var boundItemDataContext = hyperLinkButton.DataContext;
         List.Remove(boundItemDataContext); // #1 Delete it directly from the list that automatically gets updated because it's an ObservableCollection.
         LongList.SelectedItem = boundItemDataContext; // #2 Set the SelectedItem property to the current DataContext, so you can delete it in the SelectionChanged eventhandler.
    }
    private void LongList_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
         var longListSelector = sender as LongListSelector;
         List.Remove(longListSelector.SelectedItem);
    }
