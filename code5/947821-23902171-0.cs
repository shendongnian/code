    private void LV_ItemClick(object sender, ItemClickEventArgs e)
    {
    	var clickedItem = (ticket)e.ClickedItem;
    	var collection = (ObservableCollection<ticket>)LV.ItemsSource;
    	int index = collection.IndexOf(clickedItem);
    }
