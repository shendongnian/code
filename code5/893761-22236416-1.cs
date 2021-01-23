    private void listFavs_Hold(object sender, System.Windows.Input.GestureEventArgs e)
    {
    	try
    	{
    		FrameworkElement element = (FrameworkElement)e.OriginalSource;
    		string item = null;
    		
    		if(element.DataContext is Favs)
    		{
    			Favs itemTmp = (Favs)element.DataContext;
    			item = itemTmp.Name;
    		}
    		else
    		{
    			item = (string)element.DataContext;
    		}		
    			
    		....
