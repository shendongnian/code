    private void listFavs_Hold(object sender, System.Windows.Input.GestureEventArgs e)
    	{
    		try
    		{
    			FrameworkElement element = (FrameworkElement)e.OriginalSource;
    			Favs item = (Favs)element.DataContext;
    			var booze = item.ToString();
    			
    			....
