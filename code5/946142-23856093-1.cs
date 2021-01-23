    private void TxtProductFamily_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
    	foreach (var addedItem in e.AddedItems)
    	{
    		var item = addedItem as String; // <-- Cast to whatever type here, string, ViewModel, int, etc.
    		if (item != null)
    		{
    			MessageBox.Show(item);
    			break;
    		}
    	}
    }
