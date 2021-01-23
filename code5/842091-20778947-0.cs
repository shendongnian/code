    foreach (var item in ctx.Items)
    {
    	if (item is MenuItem && ((MenuItem)item).Name == "renameMenuItem")
    	{
    		var renameMenuItem = (MenuItem) item;
    		renameMenuItem.IsEnabled = false;
    	}
    }
