	public void ShowPlugins() 
	{
		foreach(IPlugin plugin in _LISTOFALLPLUGINS) 
		{
			TabItem ti = new TabItem();
			ti.Header = plugin.Name;
			UserControl uc = app.PluginControl;
			if (uc != null)
			{
				ti.Content = uc;
			}
			MYTAB.Items.Add(ti); 
		}
	}
	
